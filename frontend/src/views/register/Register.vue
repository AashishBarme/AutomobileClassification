<template>
<section>
        <form class="hero" >
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">FirstName :</label>
              <div class="col-sm-10">
                <input type="text" v-model="object.firstName" class="form-control" />
              </div>
            </div>
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">Middle Name :</label>
              <div class="col-sm-10">
                <input type="text" v-model="object.middleName" class="form-control"/>
              </div>
            </div>
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">Last Name :</label>
              <div class="col-sm-10">
                <input type="text" v-model="object.lastName" class="form-control"/>
              </div>
            </div>
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">Username :</label>
              <div class="col-sm-10">
                <input type="text" v-model="object.userName" class="form-control"/>
              </div>
            </div>
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">Password :</label>
              <div class="col-sm-10">
                <input type="text" v-model="object.password" class="form-control"/>
              </div>
            </div>
            <div class="form-group row">
              <label for="staticEmail" class="col-sm-2 col-form-label">Email :</label>
              <div class="col-sm-10">
                <input type="email" v-model="object.email" class="form-control"/>
              </div>
            </div>

           <button type="button" ref="SubmitButton"  v-on:click="SubmitForm" class="btn btn-primary">Save</button>
        </form>

           </section>

</template>
<script>
import Register from './Register';
export default Register;
</script>