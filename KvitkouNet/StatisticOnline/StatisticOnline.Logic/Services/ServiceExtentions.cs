using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using StatisticOnline.Data.Context;
using StatisticOnline.Logic.Interfaces;

namespace StatisticOnline.Logic.Services
{
    public static class ServiceExtentions
    {
        public static IServiceCollection StatisticOnlineServices(this IServiceCollection services)
        {
            var mock = new Mock<IStatisticOnlineService>();

           // mock.Setup(_ => _.GetAllUsers());

            services.AddScoped<IStatisticOnlineService>(_ => mock.Object);
            return services;
        }

        /// <summary>
        /// Добавление LoggingDbContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            const string connectionString = "Data Source=StatisticOnline.db";
            services.AddDbContext<WebApiContext>(opt => opt.UseSqlite(connectionString));
            return services;
        }
    }
}
