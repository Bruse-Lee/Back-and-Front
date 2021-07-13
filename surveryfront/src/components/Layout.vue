<template>
  <el-container>
    <el-aside>
      <sidebar></sidebar>
    </el-aside>
    <el-container>
      <el-header class="header">
        <headbar></headbar>
      </el-header>
      <el-main>
        <router-view></router-view>
      </el-main>
      <el-footer>Footer</el-footer>
    </el-container>
  </el-container>
</template>

<script>
import Sidebar from "../components/sidebar/sidebar.vue";
import Headbar from "../components/headNavbar/headBar.vue";
export default {
  components: {
    Sidebar,
    Headbar,
  },
  methods: {},
  data() {
    return {
      isCollapse: false,
    };
  },
};
</script>

<style scoped>
body {
  margin: 0px;
  padding: 0px;
}
.el-aside {
  background-color: gray;
}
.el-header {
  background-color: skyblue;
}
.el-main {
  background-color: white;
  min-height: calc(100vh - 120px);
}
.el-footer {
  background-color: pink;
}
</style>