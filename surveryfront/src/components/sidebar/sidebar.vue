<template>
  <el-menu
    default-active="2"
    class="el-menu-vertical-demo"
    background-color="#012451"
    text-color="#fff"
    active-text-color="#ffd04b"
    router
  >
    <el-submenu index="2">
      <template slot="title">
        <i class="el-icon-location"></i>
        <span>主页导航</span>
      </template>
      <el-menu-item-group>
        <el-menu-item index="/home" route="/home">首页</el-menu-item>
        <el-menu-item class="el-icon-edit" index="/log" route="/log">
          日志管理</el-menu-item
        >
        <el-menu-item class="el-icon-user" index="1-3"> 个人信息</el-menu-item>
      </el-menu-item-group>
      <el-submenu index="1-4">
        <template slot="title">权限管理</template>
        <el-menu-item
          class="el-icon-s-custom"
          index="/userController"
          route="/userController"
          >用户管理</el-menu-item
        >
        <ul>
          <li><a href="">用户列表</a></li>
          <li><a href="">添加用户</a></li>
        </ul>
      </el-submenu>
    </el-submenu>
    <el-menu-item>
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
    </el-menu-item>
  </el-menu>
</template>

<script>
export default {
  name: "sidebarItem",
  props: {
    meuns: {
      type: Array,
      require: true,
    },
  },
};
</script>