import Vue from 'vue';
import VueRouter from 'vue-router';
import CategoryListing from '../views/category-listing/CategoryListing.vue';
import HomePageList from '../views/listing/HomePageList.vue';
import Login from '../views/login/Login.vue';
import PostDetails from '../views/post-details/PostDetails.vue';
import Register from '../views/register/Register.vue';
import Upload from '../views/uploads/Upload.vue';
import UserDetail from '../views/user-detail/UserDetail.vue';
import Setting from '../views/setting/Setting.vue';

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
        path:"/profile",
        name:"UserDetail",
        component:UserDetail
    },
    {
        path:"/setting",
        name:"Setting",
        component:Setting
    },
    {
        path: "/post/:url",
        name: "PostDetail",
        component: PostDetails
    },
    {
        path: "/category/:url",
        name: "CategoryDetail",
        component: CategoryListing
    },

]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes,
    scrollBehavior() {
        document.getElementById('app').scrollIntoView();
    }
})


export default router