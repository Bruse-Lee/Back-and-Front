import Layout from '../components/Layout'
// 用户列表在项目运行时进行加载,提高加载速度的同时也会使项目首次加载时间延长
import userList from '../components/authController/userController/userList'

let routes = [
    {
        path: '/',
        component: Layout, // 异步加载 (懒加载)
        redirect: { path: '/dashboard' },
        meta: {
            title: "根目录",
            icon: 'bx bx-notification',
            style: 'color:#181818',
            // hidden: true,
        },
        children: [
            {
                path: 'dashboard',
                name: 'dashboard',
                meta: {
                    title: "仪表盘",
                    icon: 'bx bxl-windows bx-flashing',
                    style: 'color:#181818'
                },
                component: () => import('../components/Dashboard/dashboard')
            },
            {
                path: 'home',
                name: 'home',
                meta: {
                    title: "首页",
                    icon: 'bx bxl-spring-boot',
                    style: 'color:#181818'
                },
                component: () => import('../components/sidebar/home')
            },
            {
                path: 'log',
                name: 'log',
                meta: {
                    title: "日志中心",
                    icon: 'bx bxl-blogger',
                    style: 'color:#181818'
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
            icon: 'bx bx-confused',
            style: 'color:#181818'
        },
        children: [
            {
                path: 'userList',
                name: 'userList',
                meta: {
                    title: "用户列表",
                    icon: 'bx bxs-user-detail',
                    style: 'color:#181818'
                },
                component: userList
            },
            {
                path: 'addUser',
                name: 'addUser',
                meta: {
                    title: "添加用户",
                    icon: 'bx bxs-user-plus',
                    style: 'color:#181818'
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
            icon: 'bx bx-user',
            style: 'color:#181818',

        },
        children: [
            {
                path: 'profile',
                name: 'profile',
                meta: {
                    title: "个人信息",
                    icon: 'bx bx-id-card bx-tada',
                    style: 'color:#181818'
                },
                component: () => import('../components/personalCenter/profile')
            },
            {
                path: 'resetPwd',
                name: 'resetPwd',
                meta: {
                    title: "密码更改",
                    icon: 'bx bxs-skull bx-burst',
                    style: 'color:#181818'
                },
                component: () => import('../components/personalCenter/resetPwd')
            },
        ]
    },
    {
        path: '/Login',
        title: "登錄",
        meta: {
            hidden: true
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