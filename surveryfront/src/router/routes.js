import Layout from '../components/Layout'
let routes = [
    {
        path: '/',
        component: Layout, // 异步加载 (懒加载)
        title: "目录",
        children: [
            {
                path: '/home',
                title: "首页",
                component: () => import('../components/sidebar/home')
            },
            {
                path: '/log',
                title: "日志中心",
                component: () => import('../components/sidebar/log')
            },
        ],
    },
    {
        path: '/authController',
        // component: Layout,
        title: "权限管理",
        name: "authController",
        children: [
            {
                path: 'userController',
                title: '用户管理',
                // component: Layout,
                name: 'userController',
                children: [
                    {
                        path: '/userList',
                        title: "用户列表",
                        component: () => import('../components/authController/userController/userList')
                    },
                    {
                        path: 'addUser',
                        title: "添加用户",
                        component: () => import('../components/authController/userController/addUser')
                    }
                ]
            }
        ],
    },
    {
        path: '/personalCenter',
        component: Layout,
        title: "个人中心",
        name: 'personalCenter',
        children: [
            {
                path: 'profile',
                title: "个人信息",
                component: () => import('../components/personalCenter/profile')
            },
            {
                path: 'resetPwd',
                title: "密码更改",
                component: () => import('../components/personalCenter/resetPwd')
            }
        ]
    },
    {
        path: '/Login',
        title: "登錄",
        component: () => import('../components/Login')
    },
    {
        path: '/Register',
        title: "注冊",
        component: () => import('../components/Register')
    },

]


export default routes