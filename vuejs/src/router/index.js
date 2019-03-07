import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'

import Login from '@/components/User/Login'
import Register from '@/components/User/Register'
import VoteIndex from '@/components/Vote/VoteIndex'
import VoteList from '@/components/Vote/VoteList'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },{
      path: '/login',
      name: 'Login',
      component: Login
    },{
      path: '/register',
      name: 'Register',
      component: Register
    },{
      path: '/home',
      name: 'Home',
      component: VoteIndex,
      children: [
        {
          path: '/',
          name: 'VoteIndex',
          component: VoteList
        }
      ]
    }
  ]
})
