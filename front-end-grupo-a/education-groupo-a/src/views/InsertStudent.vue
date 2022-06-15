<template>
    <div>
        <v-container fluid>
            <div v-if="edited != undefined">
                <v-alert dense type="success">{{edited}}</v-alert>
            </div>
            <div v-if="error != undefined">
                <v-alert dense type="error">{{error}}</v-alert>
            </div>
            <v-toolbar flat>
                <v-toolbar-title>Student insert</v-toolbar-title>
            </v-toolbar>
            <v-text-field v-model="ra" label="RA" disabled hint='12334554' ></v-text-field>
            <v-text-field v-model="name" label="Student Name" clearable ></v-text-field>
            <v-text-field v-model="mail" label="Student Mail" clearable hint="email@gmail/hotmail/outlook.com"></v-text-field>
            <v-text-field v-model="itin" label="Student Itin" hint="000.000.000-00"></v-text-field><br>
            <v-btn color='primary' small @click="update" style="text-decoration: none;">Save student</v-btn> 
            <router-link :to="{name: 'home'}" style="text-decoration: none; margin-left: 10px">
                <v-btn color="error" small>Cancel</v-btn>
            </router-link>
        </v-container>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'InsertStudentView',
    created() {

    },
    data() {
        return {
            ra: 0,
            name: "",
            mail: "",
            itin: "",
            error: undefined,
            edited: undefined,
        }
    }, 
    methods: {
        update() {
            axios.post("https://localhost:30931/api/v1/students/",{
                ra: Number(this.ra),
                name: this.name,
                mail: this.mail,
                itin: this.itin
            }).then(res => {
                console.log(res);
                this.edited = "User Inserted Successfully";
                setTimeout(() =>{this.$router.push({name: "home"})}, 1000);
            }).catch(err => {

                var errorMessage = "";

                err.response.data.exceptions.forEach(element => {
                    errorMessage += element.message + ", ";
                });     

                this.error = `Error: ${errorMessage.substring(0, errorMessage.length-2)}`;
            })
        }
    }
}
</script>

<style scoped>
</style>