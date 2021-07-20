import Vue from 'vue'
import VueRouter from 'vue-router'
import routes from './routes'

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
    next()
})

export default router