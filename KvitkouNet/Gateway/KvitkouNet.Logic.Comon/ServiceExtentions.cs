using System.Collections.Generic;
using System.Linq;
using KvitkouNet.Logic.Common.Services.Security;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace KvitkouNet.Logic.Common
{
    public static class ServiceExtentions
    {

        /// <summary>
        /// Регистрация ISecurityService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSecurityService(this IServiceCollection services)
        {
            var mock = new Mock<ISecurityService>();

            services.AddScoped<ISecurityService>(_ => mock.Object);
            return services;
        }
    }
}
