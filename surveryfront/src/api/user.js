import request from '../utils/request'

export function deleteById(id){
    return request.delete(`/user/${id}`)
}

export function GetList(){
    return request.get('/user')
}
