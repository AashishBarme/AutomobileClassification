<template>
        <section class="hero">
          <div v-if="loading">
            <p><i>loading ...</i></p>
          </div>
          <div v-else>
         <div class="container">
          <div class="row">
         <div v-if="object.length > 0" class="col-lg-12">
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
         </div>
         <div v-else >
             <h1>No Data Found</h1>
         </div>

          </div><!--/ row -->
         </div><!--/ container -->
          </div>
        </section>
</template>
<script>
import CategoryListing from './CategoryListing';
export default CategoryListing;
</script>
<style scoped src="./CategoryListing.css"></style>