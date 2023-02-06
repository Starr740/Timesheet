import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import TimeSheet from '@/components/Timesheet'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/time-sheet',
      name: 'TimeSheet',
      component: TimeSheet
    }
  ]
})
