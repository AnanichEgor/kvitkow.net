using Microsoft.Extensions.DependencyInjection;
using Moq;
using Security.Logic.Services;

namespace Security.Logic
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
