using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Data.Context;

namespace Security.Data
{
    public static class DataExtensions
    {
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
            return services;
        }
    }
}
