using System.Linq;
using ContosoPizza.Models;
using ContosoPizza.Parmas;
using ContosoPizza.Repository;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Utils;
using ContosoPizza.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ContosoPizza.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        // 存储配置的变量
        private IConfiguration _configuration;
        private IRepository<User> _userRepository;
        private IRepository<AuditInfo> _auditInfo;
        // 存储Token配置参数
        private TokenParameter _tokenParameter;

        // 依赖注入
        public UserController(IConfiguration configuration, IRepository<User> userRepository,IRepository<AuditInfo> auditInfo)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _auditInfo = auditInfo;
            _tokenParameter = _configuration.GetSection("TokenParameter").Get<TokenParameter>();
        }

        // GET all action
        [HttpGet]
        public dynamic Get()
        {

            var user = _userRepository.Table.ToList();
            if (user == null)
                return NotFound();

            var res = new
            {
                Code = 200,
                Data = user,
                Msg = "获取列表成功！"
            };

            return JsonHelper.Serialize(res);
        }


        // GET by Id action
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            return new
            {
                Code = 200,
                Data = user,
                Msg = "获取指定Id用户成功"
            };
        }


        // POST action
        [HttpPost]
        // 指定应用此属性的类或方法不需要授权。
        [Route("register")]
        [AllowAnonymous]
        public dynamic Post([FromBody]UserCreate users)
        {
            var username = users.username.Trim();
            var password = users.password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new{
                    Code = 104,
                    Msg = "用户名不能为空!"
                }; // 204 No Content：服务器成功处理了请求，但没返回任何内容
            }

            var hasUser = _userRepository.Table.Where(x => x.Username == username).SingleOrDefault();

            if (hasUser != null)
            {
                return new
                {
                    Code = 1000,
                    Msg = "用户名已存在,请确认后重试！"
                };
            }
            else
            {
                var user = new User
                {
                    Username = users.username,
                    Password = users.password
                };
                _userRepository.Insert(user);

                return new
                {
                    Code = 200,
                    Data = user,
                    Msg = "创建用户成功！"
                };
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public dynamic Put(int id, UserCreate updateuser)
        {
            var username = updateuser.username.Trim();
            var password = updateuser.password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new
                {
                    Code = 1000,
                    Data = "",
                    Msg = "用户名或密码不能为空,请确认后重试！"
                };
            }

            var user = _userRepository.GetById(id);

            if (user == null)
            {
                return new
                {
                    Code = 1000,
                    Data = user,
                    Msg = "此用户不存在,请确认后重试！"
                };

            }


            user.Username = updateuser.username;
            user.Password = updateuser.password;

            _userRepository.Update(user);

            return new
            {
                Code = 200,
                Data = user,
                Msg = "更新成功!"
            };

        }


        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            var user = _userRepository.GetById(id);

            if (user is null)
                return NotFound();

            _userRepository.Delete(id);

            return new
            {
                Code = 200,
                Data = "",
                Msg = "成功删除指定用户！"
            };
        }

        [AllowAnonymous]
        [HttpPost, Route("/api/login")]
        public dynamic GetToken(UserCreate users)
        {
            var username = users.username.Trim();
            var password = users.password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return NoContent(); // 204 No Content：服务器成功处理了请求，但没返回任何内容
            }

            var user = _userRepository.Table.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return new
                {
                    Code = 1000,
                    Data = "",
                    Msg = "用户名或密码错误，请重新尝试！"
                };
            }

            var token = TokenHelper.GenerateToekn(_tokenParameter, user.Username);
            var refreshToken = "112358";

            return new
            {
                Code = 200,
                Data = new { Token = token, refreshToken = refreshToken },
                Msg = "用户登陆成功！"
            };

        }

        [AllowAnonymous]
        [HttpPost, Route("refreshtoken")]
        public dynamic RefreshToken(RefreshTokenDTO refresh)
        {

            var username = TokenHelper.ValidateToken(_tokenParameter, refresh);

            if (string.IsNullOrEmpty(username))
            {
                return new
                {
                    Code = 1000,
                    Data = "",
                    Msg = "Token authenticate fail"
                };
            }

            var token = TokenHelper.GenerateToekn(_tokenParameter, username);
            var refreshToken = "112358";


            return new
            {
                Code = 200,
                Data = new { Token = token, refreshToken = refreshToken },
                Msg = "Refresh Token Successful!"
            };
        }
    }
}