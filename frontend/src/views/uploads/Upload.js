import Config from "../../config/Config"
import axios from 'axios';


export default {
    name : "Upload",
    data() {
        return {
            object:{
                categoryId : 0
            },
            categoryLoading : true,
            categoryLoaded: false,
            topicImage : null,
            CategoriesList : {},
            currentUser : JSON.parse(localStorage.getItem("user"))
        }
    },
    mounted(){
        this.ListCategories();
    },
    methods:{
        SubmitForm()
        {
            let formData = new FormData();
            formData.append("Image", this.topicImage, this.topicImage.name)
            formData.append("Title", this.$data.object.title)
            formData.append("CategoryId", this.$data.object.categoryId)
            formData.append("UserId", this.$data.currentUser.id)
            formData.append("ImageName", this.topicImage.name)
            try {
                axios({
                    method: "post",
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    },
                    url : Config.API_BASE_URL + "posts",
                    data: formData
                })
                .then(
                    (response) => {
                       if(response.status >= 200)
                       {
                        this.$router.go('/');
                       }
                });
            } catch (error) {
                console.log(error)
            }
        },


        ListCategories()
        {
            try {
                axios
                 .get(Config.API_BASE_URL+"categories/list")
                 .then((response) => {
                     this.$data.CategoriesList = response.data;
                 })
            } catch (error) {
                console.log(error);
            }
        },

        UploadImage(e)
        {
            this.categoryLoading = false;
            const file = e.target.files[0];
            console.log(file);
            this.topicImage = file;
            let formData = new FormData();
            formData.append("imageFile", this.topicImage, this.topicImage.name)
            try {
                axios({
                    method: "post",
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    },
                    url : Config.API_BASE_URL + "imageclassification",
                    data: formData
                })
                .then(
                    (response) => {
                        this.$data.categoryLoaded = true;
                        this.GetCategoryId(response.data.predictedLabel);
                        this.$data.object.Image = this.topicImage
                })
                .catch(error => { console.error(error); this.categoryLoading = true})
                .finally(() => (this.categoryLoading = true)) ;
            } catch (error) {
                console.log(error)
            }

        },


        GetCategoryId(predictedLabel)
        {
            try {
                axios({
                    method: "get",
                    url : Config.API_BASE_URL + "category/getid/" + predictedLabel
                })
                .then(
                    (response) => {
                       this.$data.object.categoryId = response.data;
                    });
            } catch (error) {
                console.log(error)
            }
        }
    }
}