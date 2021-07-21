<template>
  <el-breadcrumb separator-class="el-icon-arrow-right">
    <el-breadcrumb-item :to="{ path: '/dashboard' }">仪表盘</el-breadcrumb-item>
    <el-breadcrumb-item :to="{ path: '/home' }">首页</el-breadcrumb-item>
    <el-breadcrumb-item :to="{ path: '/userController/userList' }">用户列表</el-breadcrumb-item>
    <el-breadcrumb-item :to="{ path: '/personalCenter/profile' }">个人信息</el-breadcrumb-item>
  </el-breadcrumb>
</template>