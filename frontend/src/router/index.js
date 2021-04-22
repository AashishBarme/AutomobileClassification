import Vue from 'vue';
import VueRouter from 'vue-router';
import HomePageList from '../views/listing/HomePageList.vue';
import Login from '../views/login/Login.vue';
import PostDetails from '../views/post-details/PostDetails.vue';
import Register from '../views/register/Register.vue';
import Upload from '../views/uploads/Upload.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Home",
        component:HomePageList
    },
    {
        path:"/login",
        name: "Login",
        component: Login
    },
    {
        path : "/register",
        name : "Register",
        component : Register
    },
    {
        path : "/upload",
        name: "Upload",
        component: Upload
    },
    {
        path: "/post/:url",
        name: "PostDetail",
        component: PostDetails
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})


export default router