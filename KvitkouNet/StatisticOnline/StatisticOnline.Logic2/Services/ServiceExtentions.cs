using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using StatisticOnline.Logic.Interfaces;

namespace StatisticOnline.Logic.Services
{
    public static class ServiceExtentions
    {
        public static IServiceCollection StatisticOnlineServices(this IServiceCollection services)
        {
            var mock = new Mock<IStatisticOnlineService>();

         //   mock.Setup(_ => _.GetAllUsers().RunSynchronously())

            services.AddScoped<IStatisticOnlineService>(_ => mock.Object);
            return services;
        }
    }
}
