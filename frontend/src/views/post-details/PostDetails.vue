<template>
        <section class="hero">
         <div class="container">
          <div class="row">	

  <div class="col-lg-12">

<div class="cardbox shadow-lg bg-white">

 <div class="cardbox-heading">

  <div class="media m-0">

   <div class="media-body">
    <h3 class="m-0">{{object.title}}</h3>
      <small><span><i class="icon ion-md-pin"></i> {{object.category}}</span></small>
      <small><span><i class="icon ion-md-time"></i> 10 hours ago</span></small>
   </div>
  </div><!--/ media -->
 </div><!--/ cardbox-heading -->

 <div class="cardbox-item">
  <img class="img-fluid" :src="object.image" :alt="object.title">
 </div><!--/ cardbox-item -->
 <div class="cardbox-base">
  <ul class="float-right">
   <li><a><i class="fa fa-comments"></i></a></li>
   <li><a><em class="mr-5">{{object.totalComments}}</em></a></li>
   <li><a><i class="fa fa-share-alt"></i></a></li>
   <li><a><em class="mr-3">03</em></a></li>
  </ul>
  <ul>
   <li><a v-on:click="PostLike"><i :class="postlikestatus"></i></a></li>
   <li><a><span>{{object.totalLikes}} Likes</span></a></li>
  </ul>
 </div><!--/ cardbox-base -->
 <div class="cardbox-comments widget">
              <div class="panel-body">
                <ul class="list-group">
                    <li v-for="item in object.comments" :key = "item.comment" class="list-group-item">
                        <div class="row">
                            <div class="col-xs-1 col-md-1 user-icon">
                                <i class="fa fa-user-circle-o" aria-hidden="true"></i>
                                </div>
                            <div class="col-xs-10 col-md-10 comment-desc">
                               <div>
                                    <div class="mic-info">
                                         <a href="#">{{item.username}}</a>
                                    </div>
                                </div>
                               <div class="comment-text">
                                    {{item.comment}}
                                </div>



                            </div>
                        </div>
                    </li>
                </ul>
            </div>
                <div class="search">

                    <input placeholder="Write a comment" type="text" v-model="comment.message">
                    <button type="button" v-on:click="PostComment"><i class="fa fa-paper-plane"></i></button>
                </div><!--/. Search -->

 </div><!--/ cardbox-like -->

</div><!--/ cardbox -->
           </div><!--/ col-lg-6 -->	


          </div><!--/ row -->
         </div><!--/ container -->
        </section>
</template>
<script>
import PostDetails from './PostDetails';
export default PostDetails;
</script>
<style scoped src="./PostDetails.css"></style>