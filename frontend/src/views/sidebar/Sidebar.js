import Config from '../../config/Config';
import axios from 'axios';
import Model from './Model';
export default {
    name :'Sidebar',
    data(){
        return {
            object: {},
            loading: false,
        }
    },
    mounted()
    {
        this.GetDataFromDb();
    },
    methods :{
        async GetDataFromDb()
        {
            this.loading = true;
            try {
                return axios
                        .get(Config.API_BASE_URL+'categories/list')
                        .then(response => {
                            this.$data.object = response.data.map(item => {
                                return new Model(item)
                            })
                        }).catch(error => {
                            console.log(error)
                            this.loading = false
                          })
                          .finally(() => (this.loading = false))
            } catch (error) {
               console.log(error)
            }
        }
    }


}