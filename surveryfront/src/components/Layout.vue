<template>
  <div>
    <el-container>
      <el-aside :style="asideStyle" class="aside">
        <sidebar :menus="menus"> </sidebar>
      </el-aside>
      <el-container>
        <el-header class="header">
          <a href="#"
            ><i class="bx bx-menu" :class="iconTurn" @click="handleCollapse"></i
          ></a>
          <el-breadcrumb separator-class="el-icon-arrow-right">
            <el-breadcrumb-item :to="{ path: '/dashboard' }"
              >仪表盘</el-breadcrumb-item
            >
            <el-breadcrumb-item :to="{ path: '/home' }"
              >首页</el-breadcrumb-item
            >
            <el-breadcrumb-item :to="{ path: '/userController/userList' }"
              >用户列表</el-breadcrumb-item
            >
            <el-breadcrumb-item :to="{ path: '/personalCenter/profile' }"
              >个人信息</el-breadcrumb-item
            >
          </el-breadcrumb>
          <header-bar></header-bar>
        </el-header>
        <el-main>
          <router-view></router-view>
        </el-main>
        <el-footer>
          Copyright © 2021 - 2021 Raccoon. All Rights Reserved. BruseLee
          版权所有
        </el-footer>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import headerBar from "./headNavbar/headBar.vue";
import Sidebar from "../components/sidebar/sidebar.vue";
import routes from "../router/routes";
export default {
  components: {
    Sidebar,
    headerBar,
  },
  data() {
    return {
      isCollapse: false,
    };
  },
  methods: {
    handleCollapse() {
      this.isCollapse = !this.isCollapse;
    },
    resolve(arr, parentPath = "") {
      let newArr = [];

      arr.forEach((route) => {
        let obj = Object.assign({}, route);
        parentPath =
          parentPath && parentPath.lastIndexOf("/") !== parentPath.length - 1
            ? parentPath + "/"
            : parentPath;

        obj.path = parentPath + obj.path;

        if (obj.children && obj.children.length > 0) {
          obj.children = this.resolve(obj.children, obj.path);
        }
        if (obj.meta.hidden) {
          if (obj.children && obj.children.length > 0) {
            obj.children.forEach((item) => {
              let temple = Object.assign({}, item);
              newArr.push(temple);
            });
          }
        } else {
          newArr.push(obj);
        }
      });
      return newArr;
    },
  },
  computed: {
    menus() {
      let newArr = this.resolve(routes);
      return newArr;
    },
    asideStyle() {
      return {
        width: this.isCollapse ? "auto" : "200px",
      };
    },
    iconTurn() {
      return {
        "icon-Turn": this.isCollapse ? true : "",
      };
    },
  },
};
</script>

<style>
body {
  margin: 0;
}

.header {
  display: flex;
  align-items: center;
  background-color: #c7ecee;
  justify-content: space-between;
  /* overflow: unset; */
  position: relative;
  box-shadow: 0px 1px 0px 0px #badc58;
}
.aside {
  box-shadow: 0.2px 0px 0px 0px #badc58;
}
.el-main {
  background-color: #dff9fb;
  min-height: calc(100vh - 120px);
}
.el-footer {
  background-color: #c7ecee;
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: fantasy;
  font-size: 23px;
  color: black;
  box-shadow: 0px -1px 0px 0px #badc58;
}
.bx-menu {
  color: black;
  font-size: 35px;
  margin: 0 5px;
  cursor: pointer;
}
.icon-Turn {
  transform: rotate(90deg);
}
</style>