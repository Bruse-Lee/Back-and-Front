using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContosoPizza.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ContosoPizza.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ContosoPizza.Token;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ContosoPizza.Filters;
using Microsoft.AspNetCore.Builder;

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
            //添加cors 服务 配置跨域处理
            // AddCors:将跨源资源共享服务添加到指定的目录中
            services.AddCors(options =>
            {
                // AddPolicy:Add a new Policy
                options.AddPolicy("any", builder =>
                {
                    builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
                    .AllowAnyHeader()
                    //.AllowCredentials()//指定处理cookie
                .AllowAnyOrigin(); //允许任何来源的主机访问
                });
            });

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

            };

            app.UseRouting();
            // Token验证中间件
            app.UseAuthentication();

            // 将CORS中间件添加到web应用程序管道中，以允许跨域请求
            app.UseCors("any");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //     app.UseSpa(spa =>
            //   {
            //       spa.Options.SourcePath = "ClientApp";

            //       if (env.IsDevelopment())
            //       {
            //           //spa.UseReactDevelopmentServer(npmScript: "start");
            //           //spa.UseVueCliServer(npmScript: "start");
            //           spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
            //       }
            //   });

        }


    }
}
