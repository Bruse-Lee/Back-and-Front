const TOKENKEY = "token"
const REFRESHTOKENKEY = "refreshToken"


export function setToken(token, refreshToken) {
    localStorage.setItem(TOKENKEY, token)
    localStorage.setItem(REFRESHTOKENKEY, refreshToken)

}

export function getToken() {
    return localStorage.getItem(TOKENKEY) || ''
}

export function getRefreshToken() {
    return localStorage.getItem(REFRESHTOKENKEY) || ''
}

export function removeToken() {
    localStorage.removeItem(TOKENKEY)
    localStorage.removeItem(REFRESHTOKENKEY)
}

export function isLogin() {
    let token = getToken()
    if (token) {
        return true
    } else {
        return false
    }
}


