import axios from "axios";
import { getToken } from '../utils/auth'


const instance = axios.create({
    // 指定axios访问的URL
    baseURL: 'http://localhost:5000/',
    // 在超时前，所有请求都会等待 5 秒
    timeout: 5000

})

instance.interceptors.request.use(
    (request) => {
        // console.log(request);
        let token = getToken();
        if (token) {
            request.headers['Authorization'] = 'Bearer ' + token
        }
        return request
    }, (err) => {
        return Promise.reject(err)
    }
)



// 设置响应拦截器
instance.interceptors.response.use((response) => {
    let result = response.data;
    if (response.status === 200) {

        return result;
    }
    return response
}),
    (err) => {
        console.log(err);
    };

export default instance