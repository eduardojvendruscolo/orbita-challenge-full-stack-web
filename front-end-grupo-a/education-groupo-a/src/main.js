import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import VueTheMask from 'vue-the-mask'

Vue.use(VueTheMask)
Vue.use(vuetify)

Vue.config.productionTip = false

new Vue({
  router,
  vuetify,
  VueTheMask,
  render: h => h(App)
}).$mount('#app')
