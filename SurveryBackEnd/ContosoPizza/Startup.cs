using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContosoPizza.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ContosoPizza.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ContosoPizza.Token;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ContosoPizza.Filters;

namespace ContosoPizza
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入数据库上下文
            services.AddDbContext<ContosoPizzaDb>(o => o.UseSqlServer());

            // 注入 IRepository接口及其实现类
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // 配置Token验证的设置
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;

                var token = Configuration.GetSection("tokenParameter").Get<TokenParameter>();

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // 当Token的过期小于5分钟时，想要让认证对这个时间生效，可以把这个值设为TimeSpan.Zero
                };
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AuditLogActionFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)  // 中间件
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();
            // Token验证中间件
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
