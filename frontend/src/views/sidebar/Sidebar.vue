<template>
    <div class="list-group">

        <a v-for="item in object" :key="item.slug" :href="item.slug" class="list-group-item list-group-item-action">
            {{item.title}}
        </a>
    </div>
</template>

<script>
import Sidebar from './Sidebar';
export default Sidebar ;
</script>
