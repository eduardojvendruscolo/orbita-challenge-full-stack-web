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
                <v-toolbar-title>Student {{name}} edit</v-toolbar-title>
            </v-toolbar>
            <v-text-field v-model="ra" label="RA" disabled hint='12334554' ></v-text-field>
            <v-text-field v-model="name" label="Student Name" clearable ></v-text-field>
            <v-text-field v-model="mail" label="Student Mail" clearable hint="email@gmail/hotmail/outlook.com" ></v-text-field>
            <v-text-field v-model="itin" label="Student Itin" disabled hint="000.000.000-00"></v-text-field><br>
            <v-btn color='secondary' small @click="update">Edit Student</v-btn> |
            <router-link :to="{name: 'home'}"><v-btn color="secondary" small>Cancel</v-btn></router-link>
        </v-container>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'EditStudentView',
    created() {
        axios.get("https://localhost:30931/api/v1/students/"+ this.$route.params.id).then(res => {
            console.log(res);
            this.ra = res.data.ra;
            this.name = res.data.name;
            this.mail = res.data.mail;
            this.itin = res.data.itin;
            this.primaryKey = res.data.primaryKey;
        }).catch(err => {
            console.log(err.response);
            this.$router.push({name: 'User'});
        })
    },
    data() {
        return {
            ra: "",
            name: "",
            email: "",
            cpf: "",
            error: undefined,
            edited: undefined,
        }
    }, 
    methods: {
        update() {
            axios.put("https://localhost:30931/api/v1/students/"+this.primaryKey,{
                ra: Number(this.ra),
                name: this.name,
                mail: this.mail,
                itin: this.itin
            }).then(res => {
                console.log(res);
                this.edited = "User Edited Successfully";
                setTimeout(() =>{this.$router.push({name: "home"})}, 1000);
            }).catch(err => {
                let errMsg = err.response.data;
                this.error = `Error: ${errMsg}`;
            })
        }
    }
}
</script>

<style scoped>
</style>