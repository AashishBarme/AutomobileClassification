import Config from '../../config/Config';
import Model from './Model';
import axios from 'axios';
export default ({
    name: 'CategoryListing',
    data(){
        return {    
            loading: false,
            object: {},
            url : this.$route.params.url,
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
                       .get(Config.API_BASE_URL + "posts/category/"+ this.$data.url)
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