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
    <!-- <el-submenu>
      <template slot="title">
        <i class="el-icon-location"></i>
        <span>主页导航</span>
      </template>
      <el-menu-item-group>
        <el-menu-item index="/home" route="/home">首页</el-menu-item>
        <el-menu-item class="el-icon-edit" index="/log" route="/log">
          日志管理</el-menu-item
        >
        <el-menu-item class="el-icon-user" index="profile" route="/profile"> 个人信息</el-menu-item>
      </el-menu-item-group>
      <el-submenu index="1-4">
        <template slot="title">权限管理</template>
        <el-submenu index="1-5">
          <template slot="title">用户管理</template>
          <ul>
            <el-menu-item index="1-6">
              <i class="el-icon-menu"></i>
              <span slot="title">用户列表</span>
            </el-menu-item>
            <el-menu-item index="1-7">
              <i class="el-icon-menu"></i>
              <span slot="title">添加用户</span>
            </el-menu-item>
          </ul>
        </el-submenu>
      </el-submenu>
    </el-submenu> -->
    <!-- <el-menu-item>
      <i class="el-icon-menu"></i>
      <span slot="title">导航二</span>
    </el-menu-item>
    <el-menu-item index="3" disabled>
      <i class="el-icon-document"></i>
      <span slot="title">导航三</span>
    </el-menu-item>
    <el-menu-item>
      <i class="el-icon-setting"></i>
      <span slot="title">导航四</span>
    </el-menu-item> -->
  </el-menu>
</template>
sidebarItem
<script>
import sidebarItem from '../sidebar/sidebarItem.vue'
export default {
  components:{
    sidebarItem
  },
  // name: "sidebarItem",
  props: {
    menus: {
      type: Array,
      require: true,
    },
  },

};
</script>