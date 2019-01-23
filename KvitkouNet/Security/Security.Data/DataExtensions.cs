using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Security.Data.Context;
using Security.Data.MapperProfiles;

namespace Security.Data
{
    public static class DataExtensions
    {
        public static ISecurityData GetISecurityData()
        {
            var o = new DbContextOptionsBuilder<SecurityContext>();
            o.UseSqlite("Data Source=./SecurityDatabase.db");
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
                ctx.Database.EnsureCreated();
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
            });
            services.AddScoped<ISecurityData, SecurityData>();

            return services;
        }
    }
}
