import axios from 'axios';
import Config from '../../config/Config';
import UpdateUserModel from './UpdateUserModel';
import UpdatePasswordModel from './UpdatePasswordModel';
export default{
    name:"Setting",
    data(){
        return {
           profile: {},
           user: JSON.parse(localStorage.getItem("user")),
           password: {},
           passwordVerify: ""
        }
    },
    methods:{
        GetProfileData()
        {
            try {
                axios
                .get(Config.API_BASE_URL+"users/"+ this.$data.user.id)
                .then(response => {
                    this.$data.profile = new UpdateUserModel(response.data)
                })
                .catch(error => {
                    console.error(error)
                })
            } catch (error) {
                console.error(error);
            }
        },
        UpdateProfile()
        {
            try {
                axios
                .put(Config.API_BASE_URL+"users/"+ this.$data.user.id, this.$data.profile)
                .then(response => {
                    if(response.status == 204)
                    {
                        this.$swal('Profile Updated Successfully');
                    }
                })
            } catch (error) {
                console.error(error)
            }
        },
        UpdatePassword(){
            try {
                axios({
                    method: "post",
                    url : Config.API_BASE_URL + "users/password",
                    data: new UpdatePasswordModel(this.$data.password)
                })
                .then(
                    (response) => {
                        if(response.status >= 200)
                        {
                            this.$data.password = {}
                            this.$swal('Profile Password Update Successfully');
                        }
                    });
            } catch (error) {
                console.log(error)
            }
        },
        PasswordChecker()
        {
            if(this.$data.password.main != this.$data.password.secondary)
            {
                this.$data.passwordVerify = "Password is not same";
            } else {
                this.$data.passwordVerify = "";
            }
        }
    },
    mounted(){
        this.GetProfileData();
    }
}