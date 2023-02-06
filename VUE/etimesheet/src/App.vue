<template>
  <div id="app">
    <header>
    <b-navbar toggleable="md">
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
      <b-navbar-brand to="/">eTimesheet</b-navbar-brand>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item to="/">Home</b-nav-item>
          <b-nav-item to="/time-sheet">Timesheet</b-nav-item>
          <b-nav-item href="#" @click.prevent="login" v-if="!activeUser">Login</b-nav-item>
          <b-nav-item href="#" @click.prevent="logout" v-else>Logout</b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </header>
    <!-- routes will be rendered here -->
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'app',
  data () {
    return {
    }
  },
}
</script>
<style>
header {
  background-color: #29C69F; ;
}
</style>