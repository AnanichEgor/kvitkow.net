using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Data.Context;
using Security.Data.MapperProfiles;

namespace Security.Data
{
    public static class DataExtensions
    {
        /// <summary>
        /// for local ef tests
        /// </summary>
        /// <returns></returns>
        public static ISecurityData GetISecurityData()
        {
            var o = new DbContextOptionsBuilder<SecurityContext>();
            o.UseSqlite("Data Source=D:\\kursi\\rep\\kvitkou-net\\KvitkouNet\\Security\\Security.Web\\SecurityDatabase.db");
            using (var ctx = new SecurityContext(o.Options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            return new SecurityData(new SecurityContext(o.Options),
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AccessRightProfile>();
                    cfg.AddProfile<AccessFunctionProfile>();
                    cfg.AddProfile<FeatureProfile>();
                    cfg.AddProfile<RoleProfile>();
                    cfg.AddProfile<UserRightsProfile>();
                    cfg.AddProfile<UserInfoProfile>();
                })));
        }

        /// <summary>
        /// Регистрация DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSecurityData(this IServiceCollection services)
        {
            var o = new DbContextOptionsBuilder<SecurityContext>();
            o.UseSqlite("Data Source=./SecurityDatabase.db");

            using (var ctx = new SecurityContext(o.Options))
            {
                var can = ctx.Database.CanConnect();
            }

            services.AddDbContext<SecurityContext>(
                opt => opt.UseSqlite("Data Source=./SecurityDatabase.db"));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AccessRightProfile>();
                cfg.AddProfile<AccessFunctionProfile>();
                cfg.AddProfile<FeatureProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<UserRightsProfile>();
                cfg.AddProfile<UserInfoProfile>();
            });

            services.AddScoped<ISecurityData, SecurityData>();

            return services;
        }
    }
}
