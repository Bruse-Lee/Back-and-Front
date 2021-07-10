let routes = [
    {
        path: '/',
        component: () => import('../components/Hi')  // 异步加载 (懒加载)
    },
    {
        path: '/Login',
        component: () => import('../components/Login')
    },
    {
        path: '/Register',
        component: () => import('../components/Register')
    }
]


export default routes