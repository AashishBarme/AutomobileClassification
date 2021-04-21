<template>
<div class="container">
  <div class="row">
    <div class="col-md-12">
      <Navbar></Navbar>
    </div>
    <div class="col-md-3">
      <Sidebar> </Sidebar>
    </div>
    <div class="col-md-9">
       <router-view/>
    </div>
  </div>
</div>


</template>

<script>
import Sidebar from './views/sidebar/Sidebar.vue';
import Navbar from './views/navbar/Navbar.vue';

export default {
  name: 'App',
  components: {Sidebar, Navbar}

}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
