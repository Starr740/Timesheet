import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import TimeSheet from '@/components/Timesheet'
import Project from '@/components/Project'
import Team from '@/components/Team'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/project',
      name: 'Project',
      component: Project
    },
    {
      path: '/team',
      name: 'team',
      component: Team
    },
    {
      path: '/time-sheet',
      name: 'TimeSheet',
      component: TimeSheet
    }
  ]
})
