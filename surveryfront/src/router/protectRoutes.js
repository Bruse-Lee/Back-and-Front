import VueRouter from 'vue-router'
import routes from './routes'
import Vue from 'vue'

Vue.use(VueRouter);

const router = new VueRouter({
    routes
});

router.beforeEach((to, from, next) => {
    const nextRoute = ["/"];
    if (nextRoute.indexOf(to.name) >= 0) {
        //未登录
        let name = localStorage.getItem("name");
        console.log(name);
        if (name == null) {
            router.push({ name: "Login" });
        }
    }

    // 已登录状态；当路由到login时，跳转至 /
    if (to.name === "Login") {
        let name = localStorage.getItem("name");
        if (name != null) {
            router.push({ name: "/" })
        }
    }
    next();
});

export default router