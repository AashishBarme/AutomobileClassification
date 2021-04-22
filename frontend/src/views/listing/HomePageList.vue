<template>
        <section class="hero">
         <div class="container">
          <div class="row">

            <div  v-for="item in object" :key="item.slug" class="col-lg-12">

            <div class="cardbox shadow-lg bg-white">

             <div class="cardbox-heading">
              <div class="media m-0">
               <div class="media-body">
                <h3 class="m-0">{{item.title}}</h3>
                <small><span><i class="icon ion-md-pin"></i> {{item.category}}</span></small>
                <small><span><i class="icon ion-md-time"></i> 10 hours ago</span></small>
               </div>
              </div><!--/ media -->
             </div><!--/ cardbox-heading -->

             <div class="cardbox-item">
               <router-link :to='{ name:"PostDetail", params:{url : item.slug}}'>
              <img class="img-fluid" :src="item.image" :alt="item.title">
               </router-link>
             </div><!--/ cardbox-item -->
             <div class="cardbox-base">
              <ul>
               <li><a><i class="fa fa-thumbs-up"></i></a></li>
               <li><a><span>{{item.postLikeCount}} Likes</span></a></li>
              </ul>
             </div><!--/ cardbox-base -->


            </div>
           </div>

          </div><!--/ row -->
         </div><!--/ container -->
        </section>
</template>
<script>
import HomePageList from './HomePageList';
export default HomePageList;
</script>
<style scoped src="./HomePageList.css"></style>