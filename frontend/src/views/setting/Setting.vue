<template>
<div class="container hero">
  <div class="row">
    <div class="col-sm-3">
      <ul class="nav nav-tabs tabs-left" role="tablist">
      <li role="presentation">
          <a href="#home" aria-controls="home" role="tab" class="active"  data-toggle="tab">Profile</a>
        </li>
      <li role="presentation">
          <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Password</a>
          </li>

    </ul>
    </div>
    <div class="col-sm-9">
      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="home">
          <h3>Profile</h3>
          <form v-on:submit.prevent="UpdateProfile">
            <div class="form-group">
                <label >Username</label>
                <input v-model="profile.userName" type="text" class="form-control"  >
            </div>
            <div class="form-group">
                <label >Email</label>
                <input v-model="profile.email" type="text" class="form-control"  >
            </div>
            <div class="form-group">
                <label >First Name</label>
                <input v-model="profile.firstName" type="text" class="form-control"  >
            </div>
            <div class="form-group">
                <label >Last Name</label>
                <input v-model="profile.lastName"  type="text" class="form-control"  >
            </div>
            <button
             type="button"
             v-on:click="UpdateProfile"
             class="btn btn-info btn-md" >
             Update
            </button>
            </form>
        </div>

        <div role="tabpanel" class="tab-pane" id="profile">
            <h3>Password</h3>
            <form  v-on:submit.prevent="UpdatePassword">
                <div class="form-group">
                    <label for="formGroupExampleInput">New Password</label>
                    <input type="password"  v-model="password.main" class="form-control" id="formGroupExampleInput" >
                </div>
                <div class="form-group">
                    <label for="formGroupExampleInput2">Re-type New Password</label>
                    <input v-on:keyup="PasswordChecker" type="password" v-model="password.secondary" class="form-control" id="formGroupExampleInput2">
                </div>
                <p v-if="passwordVerify" class="text-danger">{{passwordVerify}}</p>
                <button
             type="button"
             v-on:click="UpdatePassword"
             class="btn btn-info btn-md" >
             Save Changes
            </button>
              </form>
        </div>
    </div>
    </div>
  </div>
</div>

</template>
<script>
import Setting from './Setting';
export default Setting;
</script>
<style scoped src="./Setting.css"></style>