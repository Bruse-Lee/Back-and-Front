import request from '../utils/request'

export default function getAudit() {
    return request.get('/audit')
}