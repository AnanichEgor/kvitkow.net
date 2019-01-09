using UserManagement.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UserManagement.Common
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            var mock = new Mock<IUserService>();

            services.AddScoped<IUserService>(_ => mock.Object);
            return services;
        }
    }
}
