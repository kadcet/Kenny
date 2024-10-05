// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import LoginPage from '../components/LoginPage.vue'
import HeaderBar from '../components/HeaderBar.vue'
import CompanyCard from '../components/CompanyCard.vue'

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
  },
  {
    path: '/',
    name: 'CompanyCard',
    component: CompanyCard
  }
]
const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
