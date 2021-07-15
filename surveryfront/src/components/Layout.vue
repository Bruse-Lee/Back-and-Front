<template>
  <div>
    <el-container>
      <el-aside :style="asideStyle">
        <sidebar :menus="menus"></sidebar>
      </el-aside>
      <el-container>
        <el-header>
          <a href="#"
            ><i
              class="el-icon-caret-bottom"
              :class="iconTurn"
              @click="handleCollapse"
            ></i
          ></a>
          <!-- <headbar>
        </headbar> -->
        </el-header>
        <el-main>
          <router-view></router-view>
        </el-main>
        <el-footer>
          Copyright © 2021 - 2021 9I Co. All Rights Reserved. BruseLee 版权所有
        </el-footer>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import Sidebar from "../components/sidebar/sidebar.vue";
// import Headbar from "../components/headNavbar/headBar.vue";
import routes from "../router/routes";
export default {
  components: {
    Sidebar,
    // Headbar,
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
        // console.log(obj.path);
        newArr.push(obj);
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

<style scoped>
body {
  margin: 0px;
  /* padding: 0px; */
}
.el-aside {
  width: auto;
  /* background-color: gray; */
}
.el-header {
  display: flex;
  align-items: center;
  background-color: skyblue;
}
.el-main {
  background-color: white;
  min-height: calc(100vh - 120px);
}
.el-footer {
  background-color: pink;
  display: flex;
  align-items: center;
  justify-content: center;
}
.el-icon-caret-bottom {
  font-size: 40px;
}
.icon-Turn{
  transform: rotate(90deg);
}
</style>