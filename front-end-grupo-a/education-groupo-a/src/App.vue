<template>
    <v-app >
      <v-toolbar elevation="5" max-height="80px" style="padding: 8px" color="rgb(230, 230, 230)">
        <v-app-bar-nav-icon> 
          <v-img src="https://maisaedu.com.br/hubfs/site-grupo-a/logo-mais-a-educacao.svg" 
                 width="60px" transition="fade-transition"></v-img> 
        </v-app-bar-nav-icon> 
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
