import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'

import Login from '@/components/User/Login'
import Register from '@/components/User/Register'
import VoteIndex from '@/components/Vote/VoteIndex'
import VoteList from '@/components/Vote/VoteList'
import AddVoteItem from '@/components/Vote/VoteAdd'
import VoteDetail from '@/components/Vote/VoteDetail'
import UserItem from '@/components/User/UserItem'


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
          path: 'Index',
          name: 'VoteIndex',
          component: VoteList
        },{
          path: 'addVoteItem',
          name: 'AddVoteItem',
          component: AddVoteItem
        },{
          path: 'votedetail/:num',
          name: 'VoteDetail',
          component: VoteDetail
        },{
          path: 'useritem',
          name: 'UserItem',
          component: UserItem
        }
      ]
    }
  ]
})
