using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace KvitkouNet.Logic.Common
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterTicketServices(this IServiceCollection services)
        {
            var mock = new Mock<IUserService>();

            services.AddScoped<IUserService>(_ => mock.Object);
            return services;
        }
    }
}
