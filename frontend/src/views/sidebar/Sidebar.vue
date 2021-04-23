<template>
    <div class="list-group hero">
        <h5 class="title-capital">category</h5>
        <a v-for="item in object" :key="item.slug" :href="'/category/'+item.slug" class="list-group-item list-group-item-action list-category">
            {{item.title}}
        </a>
    </div>
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