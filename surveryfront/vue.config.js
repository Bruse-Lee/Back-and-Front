module.exports = {
    devServer: {
        proxy: {
            '/api': {
                //  target: 'http://127.0.0.0:8080',
                target: 'http://www.baidu.com',
                changeOrigin: true,
                pathRewrite: {
                    '^/api': ''
                }
            }
        },
        overlay: {
            warnings: false,
            errors: false
        }

    }
}