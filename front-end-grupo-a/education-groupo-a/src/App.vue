<template>
    <v-app >
      <v-toolbar elevation="5" max-height="80px" style="padding: 8px">
        <v-app-bar-nav-icon> <v-img src="./assets/grupoa.jpeg" width="60px" transition="fade-transition"></v-img> </v-app-bar-nav-icon> 
        <v-toolbar-title>Grupo A Educação</v-toolbar-title>
      </v-toolbar> 
      <v-main>
        <router-view/>
      </v-main>
    </v-app>
</template>

<script>

export default {
  name: 'App',
  data: () => ({
  }),
};
</script>
