import Vue from 'vue'
import App from './App.vue'
import router from "./router"
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios'
// import qs from 'qs'

import echarts from 'echarts'


Vue.prototype.$echarts = echarts

// 指定axios访问的URL
axios.defaults.baseURL = 'http://localhost:5000'
// 在超时前，所有请求都会等待 2.5 秒
axios.defaults.timeout = 2500

Vue.config.productionTip = false

Vue.use(ElementUI);

Vue.prototype.$axios = axios;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

