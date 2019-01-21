using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StatisticUser.Data;

namespace StatisticUser.Logic.Services
{
    public static class ServiceExtentions
    {
        /// <summary>
        /// Добавление WebApiContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            const string connectionString = "Data Source=StatisticUsers.db";
            services.AddDbContext<WebApiContext>(opt => opt.UseSqlite(connectionString));
            return services;

        }
    }
}
