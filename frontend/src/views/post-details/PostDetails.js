import axios from 'axios';
import Config from '../../config/Config';
import CommentModel from './CommentModel';
import Model from './Model';
import Helpers from '../../helpers/Helpers';
export default{
    name:"PostDetail",
    data(){
        return{
            object: {},
            comment: {},
            postlike: {},
            postlikestatus: "fa fa-heart-o",
            url : this.$route.params.url,
            currentUser : JSON.parse(localStorage.getItem("user")),
            helpers: new Helpers()
        }
    },
    mounted(){
        this.GetDataFromDb();
    },
    methods:{
        GetDataFromDb()
        {
            try {
                axios
                .get(Config.API_BASE_URL+"posts/details/"+ this.$data.url)
                .then(response => {
                    this.$data.object = new Model(response.data)
                })
                .catch(error => {
                    console.error(error)
                })
            } catch (error) {
                console.error(error);
            }
        },
        PostComment()
        {
            if(this.$data.comment.userId == null)
            {
                this.$data.helpers.DisplayErrorMessageIfNotLoggedIn();
            } else {
                this.$data.show = true;
                this.$data.comment.postId = this.$data.object.id;
                this.$data.comment.userId = this.$data.currentUser.id;

                try {
                    axios({
                        method: "post",
                        url : Config.API_BASE_URL + "posts/comments",
                        data: new CommentModel(this.$data.comment)
                    })
                    .then(
                        (response) => {
                            if(response.data > 0)
                            {
                                this.$data.comment.message = "";
                                this.UpdatePostCommentList(this.$data.comment.postId);
                            }
                        });
                } catch (error) {
                    console.log(error)
                }
            }
        },
        UpdatePostCommentList(postId)
        {
            try {
                axios({
                    method: "get",
                    url : Config.API_BASE_URL + "posts/comments/" + postId,
                })
                .then(
                    (response) => {
                      this.$data.object.comments = response.data
                      this.$data.object.totalComments = response.data.length
                    });
            } catch (error) {
                console.log(error)
            }
        },
        PostLike()
        {
            if(this.$data.comment.userId == null)
            {
               this.$data.helpers.DisplayErrorMessageIfNotLoggedIn();
            } else {
                this.$data.show = true;
                this.$data.postlike.postId = this.$data.object.id;
                this.$data.postlike.userId = this.$data.currentUser.id;
                try {
                    axios({
                        method: "post",
                        url : Config.API_BASE_URL + "posts/like",
                        data: this.$data.postlike
                    })
                    .then(
                        (response) => {
                            if(response.data > 0)
                            {
                                this.$data.postlikestatus = "fa fa-heart";
                                this.UpdatePostLike(this.$data.object.id);
                            }
                        });
                } catch (error) {
                    console.log(error)
                }
            }
        },
        UpdatePostLike(postId)
        {
            try {
                axios({
                    method: "get",
                    url : Config.API_BASE_URL + "posts/likes/" + postId,
                })
                .then(
                    (response) => {
                      this.$data.object.totalLikes = response.data
                    });
            } catch (error) {
                console.log(error)
            }
        },


    }
}