import Vue from 'vue'
import App from './App.vue'
import Router from './router'
import vuetify from './plugins/vuetify'
import VueTheMask from 'vue-the-mask'

Vue.use(VueTheMask)
Vue.use(vuetify)
Vue.use(Router)

Vue.config.productionTip = false

new Vue({
  Router,
  vuetify,
  VueTheMask,
  render: h => h(App)
}).$mount('#app')
