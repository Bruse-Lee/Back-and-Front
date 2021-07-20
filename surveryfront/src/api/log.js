import request from '../utils/request'

export function getAudit(params) {
    return request.get('/audit', { params: params })
}