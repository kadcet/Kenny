// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import LoginPage from '../components/LoginPage.vue'
import HeaderBar from '../components/HeaderBar.vue'

const routes = [
  {
    path: '/',
    name: 'LoginPage',
    component: LoginPage
  },
  {
    path: '/',
    name: 'HeaderBar',
    component: HeaderBar
  }
]
const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
