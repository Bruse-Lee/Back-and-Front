import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from './routes'
import NProgress from 'nprogress'
import 'nprogress/nprogress.css'

Vue.use(VueRouter)


let router = new VueRouter({
    mode: 'history',
    routes
})

router.beforeEach((to, from, next) => {
    if (!localStorage.getItem("token")) {
        if (to.path !== '/login') {
            return next('/login')
        }
    }
    NProgress.start();
    console.log("全局前置守卫");
    next()
})

router.afterEach(() => {
    NProgress.done()
    console.log("全局后置钩子");
})

export default router