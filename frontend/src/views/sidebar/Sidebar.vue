<template>
<section class="hero">
    <div v-if="loading">
            <p><i>loading ...</i></p>
          </div>
          <div v-else>
            <div class="list-group ">
                <a v-for="item in object" :key="item.slug" :href="'/category/'+item.slug" class="list-group-item list-group-item-action list-category">
                    {{item.title}}
                </a>
            </div>
          </div>
</section>
</template>

<script>
import Sidebar from './Sidebar';
export default Sidebar ;
</script>
<style scoped>
    .list-category
    {
        padding: 5px 1px 5px 1px;
        border:0;
        border-bottom: 1px solid rgba(0,0,0,.125);
    }
</style>