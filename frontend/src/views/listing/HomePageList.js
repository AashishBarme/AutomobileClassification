import Config from '../../config/Config';
import Model from './Model';
import axios from 'axios';
export default ({
    name: 'HomePageList',
    data(){
        return {    
            loading: false,
            object: {},
        }
    },
    mounted()
    {
        this.GetDataFromDb();
    },
    methods : {
        async GetDataFromDb()
        {
            this.loading = true;
            try {
                return axios
                       .get(Config.API_BASE_URL + "posts/list")
                       .then(response => {
                           this.$data.object = response.data.posts.map(item=> {
                               return new Model(item)
                           })
                       })
                       .catch(error => {
                        console.log(error)
                        this.loading = false
                      })
                      .finally(() => (this.loading = false))
              } catch (error) {
                  console.log(error);
              }
        }
    }
})