<template>
  <!-- <el-scrollbar> -->
    <el-menu
      default-active="1"
      class="el-menu-vertical-demo"
      background-color="#c7ecee"
      text-color="#182C61"
      active-text-color="#2e86de"
      router
      :collapse="collapse"
    >
      <sidebarItem :menus="menus"></sidebarItem>
      
    </el-menu>
  <!-- </el-scrollbar> -->
</template>

<script>
import sidebarItem from "../sidebar/sidebarItem.vue";
export default {
  components: {
    sidebarItem,
  },
  props: {
    menus: {
      type: Array,
      require: true,
    },
    collapse: {
      type: Boolean,
      default: false,
    },
  },
};
</script>

<style scoped>
.el-menu {
  height: 100vh;
  text-align: center;
  border-right: none;
   /* box-shadow: 0.2px 0px 0px 0px #badc58; */
  font-weight: 800;
}
.el-menu-vertical-demo{
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

</style>