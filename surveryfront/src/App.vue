<template>
  <div id="app">
    <router-view v-if="isRouterAlive"></router-view>
  </div>
</template>

<script>
export default {
  name: "app",
  // provide与inject:使用场景：
  // 由于vue有$parent属性可以让子组件访问父组件。但孙组件想要访问祖先组件就比较困难。
  // 通过provide/inject可以轻松实现跨级访问祖先组件的数据

  // 父组件中返回要传给下级的数据
  provide() {
    return {
      reload: this.reload,
    };
  },
  data() {
    return {
      isRouterAlive: true,
    };
  },
  components: {
    // HelloWorld
  },
  methods: {
    reload() {
      this.isRouterAlive = false;
      this.$nextTick(function () {
        this.isRouterAlive = true;
      });
    },
  },
  watch: {
    $route: {
      handler: function (now) {
        document.getElementById("app").scrollTo(0, 0);
        console.log(now.path);
      },
      deep: true,
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;

  /* margin: 0%;
  padding: 0%;
  margin-left: 0px;
  margin-top: 0px;
  margin-right: 0px;
  margin-bottom: 0px; */
}
</style>
