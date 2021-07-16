import Layout from '../components/Layout'

let routes = [
    {
        path: '/',
        component: Layout, // 异步加载 (懒加载)
        redirect: { path: '/dashboard' },
        meta: {
            title: "根目录",
            icon: 'bx bx-category'
        },
        children: [
            {
                path: 'dashboard',
                name: 'dashboard',
                meta: {
                    icon: 'bx bx-dialpad',
                    title: "仪表盘"
                },
                component: () => import('../components/Dashboard/dashboard')
            },
            {
                path: 'home',
                name: 'home',
                meta: {
                    title: "首页",
                    icon: 'bx bxl-spring-boot'
                },
                component: () => import('../components/sidebar/home')
            },
            {
                path: 'log',
                name: 'log',
                meta: {
                    title: "日志中心",
                    icon: 'bx bxl-blogger'
                },
                component: () => import('../components/sidebar/log')
            },

        ],
    },
    {
        // path: '/authController',
        // component: Layout,
        // name: "authController",
        // meta: {
        //     title: "权限管理",
        //     icon: 'bx bxs-user'
        // },
        // children: [
        //     {
        path: '/userController',
        name: 'userController',
        component: Layout,
        meta: {
            title: "用户管理",
            icon: 'bx bx-confused'
        },
        children: [
            {
                path: 'userList',
                name: 'userList',
                meta: {
                    title: "用户列表",
                    icon: 'bx bxs-user-detail'
                },
                component: () => import('../components/authController/userController/userList')
            },
            {
                path: 'addUser',
                name: 'addUser',
                meta: {
                    title: "添加用户",
                    icon: 'bx bxs-user-plus'
                },
                component: () => import('../components/authController/userController/addUser')
            }
        ]
        // }
        // ],
    },
    {
        path: '/personalCenter',
        name: 'personalCenter',
        component: Layout,
        meta: {
            title: "个人中心",
            icon: 'bx bxs-user-circle'
        },
        children: [
            {
                path: 'profile',
                name: 'profile',
                meta: {
                    title: "个人信息",
                    icon: 'bx bx-user-circle'
                },
                component: () => import('../components/personalCenter/profile')
            },
            {
                path: 'resetPwd',
                name: 'resetPwd',
                meta: {
                    title: "密码更改",
                    icon: 'bx bxl-tux'
                },
                component: () => import('../components/personalCenter/resetPwd')
            },
        ]
    },
    {
        path: '/Login',
        title: "登錄",
        meta:{
            hidden:true
        },
        component: () => import('../components/Login/Login')
    },
    // {
    //     path: '/Register',
    //     title: "注冊",
    //     component: () => import('../components/Register')
    // },

]


export default routes