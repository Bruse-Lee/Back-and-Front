using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContosoPizza.Models;
using ContosoPizza.Token;
using Microsoft.IdentityModel.Tokens;

namespace ContosoPizza.Utils
{
    public class TokenHelper
    {
        public static string GenerateToekn(TokenParameter tokenParameter, string username)
        {
            var claims = new[]
            {
                // 指定实体角色的声明的URI
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "admin"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParameter.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(tokenParameter.Issuer, null, claims, expires: DateTime.UtcNow.AddMinutes(tokenParameter.AccessExpiration), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        /// <summary>
        /// 验证token并从中得到用户名
        /// </summary>
        /// <param name="tokenParameter">token设置</param>
        /// <param name="refresh">刷新token的模型，里面是token和refreshToken</param>
        public static string ValidateToken(TokenParameter tokenParameter, RefreshTokenDTO refresh)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal claim = handler.ValidateToken(refresh.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenParameter.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                }, out SecurityToken securityToken);

                return claim.Identity.Name;
            }
            catch
            {
                return null;
            }
        }
    }
}