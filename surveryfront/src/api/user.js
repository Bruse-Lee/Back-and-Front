import request from '../utils/request'

// 删除
export function deleteById(id){
    return request.delete(`/user/${id}`)
}

// 查询所有列表
export function GetList(){
    return request.get('/user')
}

// 查询指定Id
export function GetById(id){
    return request.get(`/user/${id}`)
}

// 修改个人信息
export function changeInfo(data){
    return request.put(`/user/${data}`)
}

// 新增用户
// export function newUser(){
//     return request.post(`/user/register`)
// }