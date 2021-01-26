import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'
import Home from '../views/Home.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    component: () => import(/* webpackChunkName: "Home" */ '../views/Home.vue')  },
  {
    path: '/SM',
    name: 'SM',
    component: () => import(/* webpackChunkName: "SM" */ '../views/SM.vue')
  },
  {
    path: '/UP',
    name: 'UP',
    component: () => import(/* webpackChunkName: "UP" */ '../views/UP.vue')
  },
  {
    path: '/NewSong',
    name: 'NewSong',
    component: () => import(/* webpackChunkName: "NewSong" */ '../views/NewSong.vue')
  },
  {
    path: '/MakeSong',
    name: 'MakeSong',
    component: () => import(/* webpackChunkName: "NewSong" */ '../views/MakeSong.vue')
  },
  {
    path: '/NewInstrument',
    name: 'NewInstrument',
    component: () => import(/* webpackChunkName: "NewInstrument" */ '../views/NewInstrument.vue')
  },
  {
    path: '/UploadSong',
    name: 'UploadSong',
    component: () => import(/* webpackChunkName: "UploadSong" */ '../views/UploadSong.vue')
  },
  {
    path: '/EditSong',
    name: 'EditSong',
    component: () => import(/* webpackChunkName: "EditSong" */ '../views/EditSong.vue')
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
