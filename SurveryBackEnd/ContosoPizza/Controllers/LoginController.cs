using System;
using System.Linq;
using ContosoPizza.Models;
using ContosoPizza.Repository;
using ContosoPizza.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ContosoPizza.Controllers
{
    public class LoginController : ControllerBase
    {
        // 存储配置的变量
        private IConfiguration _configuration;
        private IRepository<User> _userRepository;
        // 存储Token配置参数
        private TokenParameter _tokenParameter;

        // 依赖注入
        public void UserController(IConfiguration configuration, IRepository<User> userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenParameter = _configuration.GetSection("TokenParameter").Get<TokenParameter>();
        }

        // 登陆判断
        // [HttpPost]
        // // public dynamic Login(string account, string password)
        // // {
        // //     var userInfo = _userRepository.Table.ToList();
        // //     var userName = userInfo.Where(x => x.Username == account).SingleOrDefault();
        // //     var passWord = userInfo.Where(x => x.Password == password).SingleOrDefault();
        // //     if (userName != null && passWord != null)
        // //     {
        // //         return new
        // //         {
        // //             Code = 200,
        // //             Data = new { Username = userName, Password = passWord },
        // //             Msg = "用户登陆成功"
        // //         };
        // //     }
        // //     return null;
        // // }
    
    }
}