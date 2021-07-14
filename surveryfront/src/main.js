import Vue from 'vue'
import App from './App.vue'
import router from "./router"
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios'

Vue.config.productionTip = false

Vue.use(ElementUI);

// Vue.use(axios)

Vue.prototype.$axios = axios;


// 跨域问题


// axios.get('http://localhost:5000/user')
//   .then(function (res) {
//     console.log(res);
//     console.log(res.data.data);
//   });

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

