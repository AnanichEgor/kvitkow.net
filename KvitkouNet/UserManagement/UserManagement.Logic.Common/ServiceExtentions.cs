using System.Collections.Generic;
using System.Linq;
using UserManagement.Logic.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UserManagement.Logic.Common
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
