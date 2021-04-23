import Model from './Model';
import axios from 'axios';
import Config from '../../config/Config';

export default{
    name:"UserDetails",
    data(){
        return{
            object: {},
            user: JSON.parse(localStorage.getItem("user"))
        }
    },
    methods:{
        GetDataFromDb()
        {
            try {
                axios
                .get(Config.API_BASE_URL+"posts/user/"+ parseInt(this.$data.user.id))
                .then(response => {
                    this.$data.object = response.data.posts.map(item=> {
                        return new Model(item)
                    })
                })
                .catch(error => {
                    console.error(error)
                })
            } catch (error) {
                console.error(error);
            }
        }
    },
    mounted(){
        this.GetDataFromDb();
    }
}