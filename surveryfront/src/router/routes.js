import Layout from '../components/Layout'
let routes = [
    {
        path: '/',
        component: Layout, // 异步加载 (懒加载)
        children: [
            {
                path: '/home',
                component: () => import('../components/sidebar/home')
            },
            {
                path: '/power',
                component: () => import('../components/sidebar/power')
            },
            {
                path:'/log',
                component:()=>import('../components/sidebar/log')
            }
        ]
    },
    {
        path: '/Login',
        component: () => import('../components/Login')
    },
    {
        path: '/Register',
        component: () => import('../components/Register')
    },

]


export default routes