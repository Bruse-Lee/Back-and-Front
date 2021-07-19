import axios from "axios";

// 指定axios访问的URL
axios.defaults.baseURL = 'http://localhost:5000'
// 在超时前，所有请求都会等待 2.5 秒
axios.defaults.timeout = 10000

// axios.defaults.Headers = 'application/json'

export default axios