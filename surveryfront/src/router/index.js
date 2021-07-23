import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from './routes'
import NProgress from 'nprogress'
import 'nprogress/nprogress.css'
import { isLogin } from '../utils/auth'

Vue.use(VueRouter)


let router = new VueRouter({
    mode: 'history',
    routes
})
const originalPush = VueRouter.prototype.push
VueRouter.prototype.push = function push(location) {

    return originalPush.call(this, location).catch(err => err)

}
router.beforeEach((to, from, next) => {
    let isAuth = isLogin()

    if (to.path === '/login') {
        if (isAuth) {
            next('/')
        } else {
            next()
        }
    } else {
        if (isAuth) {
            next()
        } else {
            next('/login')
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