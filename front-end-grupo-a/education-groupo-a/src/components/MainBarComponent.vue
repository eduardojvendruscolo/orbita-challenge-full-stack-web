<template>
    <v-container fluid>
        <v-toolbar flat>
            <v-toolbar-title>Students</v-toolbar-title>
        </v-toolbar>

        <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr >
                        <th class="text-left">RA</th>
                        <th class="text-left">Name</th>
                        <th class="text-left">Mail</th>
                        <th class="text-left">Itin</th>
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
            page: null
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
            axios.get('https://localhost:30931/api/v1/students?pageSize=10&pageOffset='+page)
                    .then((res) => {
                            this.students = res.data.records;
                            this.totalPages = res.data.totalPages;
                            this.page = res.data.page;
                    })
                    .catch((error) => {
                            console.log(error);
                    });
        }
    }
}
</script>
