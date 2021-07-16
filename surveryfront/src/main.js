import Vue from 'vue'
import App from './App.vue'
import router from "./router"
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios'

// import qs from 'qs'

import echarts from 'echarts'


Vue.prototype.$echarts = echarts

Vue.config.productionTip = false

Vue.use(ElementUI);

Vue.prototype.$axios = axios;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')



