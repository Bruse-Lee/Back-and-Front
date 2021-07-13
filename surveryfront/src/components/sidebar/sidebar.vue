<template>
  <el-menu
    default-active="2"
    class="el-menu-vertical-demo"
    background-color="#012451"
    text-color="#fff"
    active-text-color="#ffd04b"
    router
  >
    <sidebarItem :menus="menus"></sidebarItem>
  </el-menu>
</template>

<script>
import sidebarItem from '../sidebar/sidebarItem.vue'
export default {
  components: {
    sidebarItem
  },
  props: {
    menus: {
      type: Array,
      require: true,
    },
  },
};
</script>