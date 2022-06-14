<template>
    <v-app >
      <v-app-bar elevation="5">
        <v-app-bar-nav-icon> <v-img src="./assets/grupoa.jpeg" width="60px"></v-img>  </v-app-bar-nav-icon> 
        <v-toolbar-title>Grupo A Educação</v-toolbar-title>
      </v-app-bar> 
      <v-main>
        <router-view/>
      </v-main>
    </v-app>
</template>

<script>

export default {
  name: 'App',
  data: () => ({
    //
  }),
};
</script>
