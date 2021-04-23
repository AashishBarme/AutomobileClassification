<template>
<div  class="container">
    <nav class="navbar navbar-expand-md navbar-light bg-light">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="/">Home <span class="sr-only">(current)</span></a>
                </li>

            </ul>
            <ul class="navbar-nav">
                <li class="nav-item" v-if="!helpers.CheckIfUserIsLoggedIn()">
                  <router-link class="nav-link" to="/login"> Log in </router-link>
                </li>
                <li class="nav-item"  v-if="!helpers.CheckIfUserIsLoggedIn()">
                  <router-link class="round-btn btn btn-primary" to="/register"> Sign up </router-link>
                </li>
                 <li class="nav-item dropdown" v-if="helpers.CheckIfUserIsLoggedIn()">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-user-circle"></i>
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                      <router-link class="dropdown-item" to="/profile">My Profile</router-link>
                      <router-link class="dropdown-item" to="/setting">Setting</router-link>
                      <a class="dropdown-item" v-on:click="Logout"><i class="fa fa-sign-out" aria-hidden="true"></i> Log Out</a>
                    </div>
                  </li>
                <li class="nav-item"  v-if="helpers.CheckIfUserIsLoggedIn()">
                  <router-link class="round-btn btn btn-primary"  to="/upload"> + Upload </router-link>
                </li>
            </ul>
        </div>
    </nav>
</div>

</template>
<script>
import Navbar from './Navbar';
export default Navbar;
</script>
<style scoped>
.navbar-nav , .navbar-nav li a {
  font-weight: 600;
}
.navbar-nav li {
      padding-left: 10px;
}
.navbarDropdownMenuLink i{
  font-size: 20px;
}
</style>