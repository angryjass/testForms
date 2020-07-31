import Vue from 'vue'
import VueRouter from 'vue-router'
import SearchForm from '../components/SearchForm'
import SendForm from '../components/SendForm'
Vue.use(VueRouter)
const routes = [
  {
    path: '/',
    component: SearchForm
  },
  {
    path: '/submit',
    component: SendForm
  }
]
const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
export default router
