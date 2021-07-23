import Vue from 'vue'
import App from './App.vue'
import router from "./router"
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios'
import { MessageBox } from "element-ui";
import * as echarts from 'echarts'
import VueQuillEditor from 'vue-quill-editor'




Vue.prototype.$axios = axios;
Vue.prototype.$echarts = echarts
Vue.prototype.$confirm = MessageBox.confirm
Vue.config.productionTip = false

Vue.use(ElementUI);
Vue.use(VueQuillEditor)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')



