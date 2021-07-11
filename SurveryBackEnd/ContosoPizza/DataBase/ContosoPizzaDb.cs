using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Database
{
    public class ContosoPizzaDb : DbContext
    {
        /// <summary>
        /// 采用依赖注入的方式的时，必须提供其构造函数，并且调用其父类构造函数
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ContosoPizzaDb(DbContextOptions options) : base(options)
        {

        }
        // 集合所操作的实体类型 DbSet<T>
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AuditInfo> AuditInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"server=.;database=ContosoPizza;uid=sa;pwd=123456;");

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     //添加种子数据
        //     modelBuilder.Entity<User>().HasData(
        //         new User
        //         {

        //             Username = "Root",
        //             Password = "123"
        //         },
        //         new User{
        //             Username = "Root2",
        //             Password = "113"
        //         }
        //     );
        // }           
    }
}