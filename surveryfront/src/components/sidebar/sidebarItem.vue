<template>
  <div>
    <div v-for="menu in menus" :key="menu.path">
      <el-submenu
        v-if="menu.children && menu.children.length > 0"
        :index="menu.path"
      >
        <template slot="title">
          <i :class="menu.meta.icon"></i>
          <span>{{ menu.meta.title }}</span>
        </template>

        <sidebar-item :menus="menu.children"></sidebar-item>
      </el-submenu>

      <el-menu-item v-else :index="menu.path">
        <i :class="menu.meta.icon"></i>
        <span slot="title">{{ menu.meta.title }}</span>
      </el-menu-item>
    </div>
  </div>
</template>

<script>
export default {
  name: "sidebarItem",
  props: {
    menus: {
      type: Array,
      require: true,
    },
  },
};
</script>

<style scoped>
@import "https://unpkg.com/boxicons@2.0.7/css/boxicons.min.css";
</style>