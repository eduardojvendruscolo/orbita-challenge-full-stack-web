<template>
    <div>
        <v-container fluid>
            <div v-if="edited != undefined">
                <v-alert dense type="success">{{edited}}</v-alert>
            </div>
            <div v-if="error != undefined">
                <v-alert dense type="error">{{error}}</v-alert>
            </div>
            
            <v-toolbar flat class="toolbar-list">
                <v-toolbar-title>Student insert</v-toolbar-title>
            </v-toolbar>

            <v-text-field v-model="ra" label="RA" disabled hint='12334554' ></v-text-field>
            <v-text-field v-model="name" label="Student Name" clearable :rules="[validateName]"></v-text-field>
            <v-text-field v-model="mail" label="Student Mail" clearable hint="email@gmail/hotmail/outlook.com" :rules="[validateMail]"></v-text-field>
            <v-text-field v-model="itin" label="Student Itin" hint="000.000.000-00" :rules="[validateItin]"></v-text-field><br>
            <v-btn color='primary' small @click="update" style="text-decoration: none;" elevation="0">Save</v-btn> 
            <router-link :to="{name: 'home'}" style="text-decoration: none; margin-left: 10px">
                <v-btn color="error" small elevation="0">Cancel</v-btn>
            </router-link>
        </v-container>
    </div>
</template>

<script>
import axios from 'axios';
import common from '../common/commonFunctions'

export default {
    name: 'InsertStudentView',
    created() {

    },
    data() {
        return {
            ra: undefined,
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
                ra: Number(this.ra === undefined ? 0 : this.ra),
                name: this.name,
                mail: this.mail,
                itin: this.itin
            }).then(res => {
                console.log(res);
                this.edited = "User Inserted Successfully";
                setTimeout(() =>{this.$router.push({name: "home"})}, 1000);
            }).catch(err => {
                var errorMessage = err.response.data.exceptions.reduce((msg, item) => msg += item.message + ', ', '');
                this.error = `Error: ${errorMessage.substring(0, errorMessage.length-2)}`;
            })
        },
        validateName() {
            return common.validations.validateName(this.name);      
        },
        validateItin() {
            return common.validations.validateCpf(this.itin);
        },
        validateMail(){
            return common.validations.validateMail(this.mail);
        }
    }
}
</script>

<style>
    .toolbar-list .v-toolbar__content {
        padding: 2px 0px;
    }
</style>