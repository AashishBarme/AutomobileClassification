<template>
     <div id="login">
        <h3 class="text-center text-white pt-5">Login form</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="login-form" class="form" v-on:submit.prevent="SubmitForm">
                          <h3>ACCOUNT LOGIN</h3>
                            <div class="form-group">
                                <input type="text" placeholder="Username" class="form-control"  
                                v-model="object.username"
                                 >
                            </div>
                            <div class="form-group">
                                <input type="password" placeholder="Password" class="form-control"

                                  v-model="object.password">
                            </div>
                             <p v-if="Message !== ''" class="text-danger">{{Message}}</p>
                            <div class="form-group">
                               <button
                                type="button"
                                v-on:click="SubmitForm"
                                class="btn btn-info btn-md"
                              >
                                Login
                              </button>

                            </div>
                        </form>
                          
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from "axios";
import Config from '../../config/Config'
export default {
    name: "Login",
    data()
    {
        return  {
              object: {},
              Message : ""
        }
    },
    methods : {
        SubmitForm()
        {
            try {
                axios({
                    method: "post",
                    url : Config.API_BASE_URL + "auth/login",
                    data: this.$data.object
                })
                .then(
                    (response) => {
                        if (typeof(response.data.token) !== 'undefined') {
                        localStorage.setItem("token", response.data.token);
                        localStorage.setItem("user",JSON.stringify(response.data.userInfo));
                         this.$router.push("/");
                        this.$router.go("/");
                        } else {
                        this.$data.Message = "username or password is incorrect"
                    }

                    });
            } catch (error) {
                console.log(error)
            }
        }
    }
}
</script>
<style scoped>
body {
  margin: 0;
  padding: 0;
  height: 100vh;
  font-family: 'Work Sans', sans-serif;
}
#login .container #login-row #login-column #login-box {
  margin-top: 90px;
  max-width: 600px;
  height: 320px;
}
#login-form h3{
  margin-bottom: 30px;
}
#login .container #login-row #login-column #login-box #login-form {
  padding: 20px;
}
#login .container #login-row #login-column #login-box #login-form #register-link {
  margin-top: -85px;
}
</style>