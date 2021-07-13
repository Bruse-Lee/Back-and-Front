<template>
     <el-breadcrumb separator-class="el-icon-arrow-right">
          <el-breadcrumb-item :to="{ path: 'home' }">首页</el-breadcrumb-item>
          <el-breadcrumb-item :to="{ path: 'power' }"
            >权限中心</el-breadcrumb-item
          >
          <el-breadcrumb-item>活动列表</el-breadcrumb-item>
          <el-breadcrumb-item>活动详情</el-breadcrumb-item>
        </el-breadcrumb>
</template>