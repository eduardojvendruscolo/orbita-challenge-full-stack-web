import Vue from 'vue'
import VueRouter from 'vue-router'
import MainBarComponent from '../components/MainBarComponent.vue'
import EditStudentView from '../views/EditStudent.vue'
import InsertStudentView from '../views/InsertStudent.vue'

console.log('MainBarComponent', MainBarComponent)

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: MainBarComponent
  },
  {
    path: '/edit/:id',
    name: 'Edit',
    component: EditStudentView
  },
  {
    path: '/insert/:id',
    name: 'Insert',
    component: InsertStudentView
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
