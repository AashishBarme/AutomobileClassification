<template>
<div id="app">
<div class="container">
  <div class="row">

      <Navbar></Navbar>

    <div class="col-md-3">
      <Sidebar> </Sidebar>
    </div>
    <div class="col-md-7">
       <router-view/>
    </div>
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
  font-family: 'Mukta', sans-serif !important;
}
body{
  font-family: 'Mukta', sans-serif !important;
}
.hero {
    padding: 2.25rem 0px !important;
    margin: 0px !important;
  }
.round-btn{
  border-radius: 25px !important;
}
input, select, textarea{
    border: 1px solid #ced4da !important;
    border-radius: 0px!important;
}
</style>
