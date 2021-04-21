import Model from './Model';
import axios from 'axios';
import Config from '../../config/Config';
export default {
    name : "Register",
    data(){
        return  {
            object : {},
            show : false
        }
    },
    methods:{
        SubmitForm() {
            this.$data.show = true;
            try {
                axios({
                    method: "post",
                    url : Config.API_BASE_URL + "users",
                    data: new Model(this.$data.object)
                })
                .then(
                    (response) => {
                        if(response.data > 0)
                        {
                            this.$router.push("/");
                            this.$router.go("/");
                        }
                    });
            } catch (error) {
                console.log(error)
            }
        }
    }
}