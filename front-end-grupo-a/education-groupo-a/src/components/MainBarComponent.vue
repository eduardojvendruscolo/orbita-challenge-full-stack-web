<template>
    <v-container fluid>

        <v-toolbar flat>
            <v-toolbar-title>Students</v-toolbar-title>
        </v-toolbar>

        <v-row>
            <v-col md="11">
                <v-text-field 
                    label="Type your search"
                    outlined
                    v-model="searchString"
                    @keyup="getStudents(1)"
                ></v-text-field>
            
            </v-col>
            <v-col md="1">
                <v-select
                    :items="items"
                    label="Page size"
                    v-model="pageSize"
                    outlined
                    @change="getStudents(1)"
                ></v-select>
            </v-col>  
        </v-row>        

        <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr >
                        <th class="text-left" @click="sortField('ra')"> <v-icon> {{tableHeaderIconRa}} </v-icon>RA</th>
                        <th class="text-left" @click="sortField('name')"><v-icon> {{tableHeaderIconName}} </v-icon>Name</th>
                        <th class="text-left" @click="sortField('mail')"><v-icon> {{tableHeaderIconMail}} </v-icon>Mail</th>
                        <th class="text-left" @click="sortField('itin')"><v-icon> {{tableHeaderIconItin}} </v-icon>Itin</th>
                        <th class="text-left">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="student in students" :key="student.ra">
                        <td>{{student.ra}}</td>
                        <td>{{student.name}}</td>
                        <td>{{student.mail}}</td>
                        <td> <the-mask :mask="['###.###.###-##']" :value="student.itin"></the-mask> </td>
                        <td>
                            <router-link :to="{name: 'Edit', params: {id: student.primaryKey}}" 
                                          style="text-decoration: none; color: inherit;margin-right: 15px">
                                <v-btn color="warning" small>Edit</v-btn>
                            </router-link> 
                            
                            <v-dialog v-model="dialog" max-width="290" :retain-focus="false">
                                <template v-slot:activator="{ on, attrs }">
                                    <v-btn color="error" small v-bind="attrs" @click='saveRA(student.ra, student.name, student.primaryKey)' v-on="on">Delete</v-btn>
                                </template>
                                <v-card >
                                    <v-card-title class="text-h5">
                                    Delete Confirmation
                                    </v-card-title>
                                    <v-card-text>Are you sure you want to delete the student {{studentName}} with RA {{studentRa}} ?</v-card-text>
                                    <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="secondary" text @click="dialog = false">
                                        Cancel
                                    </v-btn>
                                    <v-btn color="secondary" text @click="deleteUser()">
                                        Yes, Delete it
                                    </v-btn>
                                    </v-card-actions>
                                </v-card>
                            </v-dialog>
                        </td>
                    </tr>
                </tbody>

            </template>                

        </v-simple-table>    

        <v-pagination
            :length="totalPages"
            v-model="page"
            @input="nextPage"   
            circle                 
        ></v-pagination>

        <router-link :to="{name: 'Insert', params: {}}" style="text-decoration: none; color: inherit;">
              <v-btn
                    class="mx-2"
                    fab
                    dark
                    color="indigo">
            <v-icon dark> mdi-plus</v-icon>
             </v-btn>  
        </router-link>


    </v-container>
</template>

<script>

import axios from 'axios'

export default {

    name: "MainBarComponent",
    created(){
        this.getStudents(1);
    },
    data(){
        return{
            search: '',
            dialog: false,
            headers: [
                { text: 'RA',value: 'ra' },
                { text: 'Name', value: 'name' },
                { text: 'Mail', value: 'mail' },
                { text: 'Itin', value: 'itin' },
                { text: 'actions', value: 'actions' }
            ],
            students:[],
            studentRa: -1,
            studentName: "",
            studentPrimaryKey: null,
            totalPages: null,
            page: null,
            searchString: null,
            fieldOrderName: null,
            fieldOrderType: "asc",
            tableHeaderIconRa: '',
            tableHeaderIconName: 'mdi-arrow-down-bold',
            tableHeaderIconMail: '',
            tableHeaderIconItin: '',
            items: [5, 10, 20, 50, 100],
            pageSize: 10
        }
    },
    methods: {
        deleteUser() {
            axios.delete('https://localhost:30931/api/v1/students/' + this.studentPrimaryKey).then(res => {
                console.log(res);
                this.students = this.students.filter(s => s.primaryKey != this.studentPrimaryKey);
                this.dialog = false;
            }).catch(err => {
                console.log(err);
            })
        },
        saveRA(ra, name, primaryKey) {
            this.studentRa = ra;
            this.studentName = name;
            this.studentPrimaryKey = primaryKey
        },
        nextPage(page){
            this.getStudents(page);
        },
        getStudents(page){
            var url = 'https://localhost:30931/api/v1/students?pageOffset=' + page;

            if (this.pageSize)
                url += '&pageSize='+this.pageSize

            if (this.searchString)
                url += '&filter='+this.searchString

            if (this.fieldOrderName)
                url += '&orderByField='+this.fieldOrderName   
                
            if (this.fieldOrderName && this.fieldOrderType)
                url += '&orderType='+this.fieldOrderType      

            axios.get(url)
                    .then((res) => {
                            this.students = res.data.records;
                            this.totalPages = res.data.totalPages;
                            this.page = res.data.page;
                    })
                    .catch((error) => {
                            console.log(error);
                    });
        },
        sortField(fieldOrderName) {

            if (fieldOrderName === this.fieldOrderName){
                if (this.fieldOrderType === "asc")
                   this.fieldOrderType = "desc"
                else    
                   this.fieldOrderType = "asc"
            }

            this.tableHeaderIconRa = ''
            this.tableHeaderIconName = ''
            this.tableHeaderIconMail = ''
            this.tableHeaderIconItin = ''

            let arrowDownIcon = 'mdi-arrow-down-bold';
            let arrowUpIcon = 'mdi-arrow-up-bold';

            switch (fieldOrderName) {
                case "ra":
                    this.fieldOrderType === "asc" ? this.tableHeaderIconRa = arrowDownIcon : this.tableHeaderIconRa = arrowUpIcon;
                    break;

                case "name":
                    this.fieldOrderType === "asc" ? this.tableHeaderIconName = arrowDownIcon : this.tableHeaderIconName = arrowUpIcon;
                    break;      
                    
                case "mail":
                    this.fieldOrderType === "asc" ? this.tableHeaderIconMail = arrowDownIcon : this.tableHeaderIconMail = arrowUpIcon;
                    break;    
                    
                default:
                    this.fieldOrderType === "asc" ? this.tableHeaderIconItin = arrowDownIcon : this.tableHeaderIconItin = arrowUpIcon;
                    break;                     

            }

            this.fieldOrderName = fieldOrderName;
            this.getStudents(1);
        }
    }
}
</script>
