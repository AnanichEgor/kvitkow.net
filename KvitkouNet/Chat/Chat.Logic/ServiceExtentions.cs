using Microsoft.Extensions.DependencyInjection;
using Chat.Logic.Services;
using Moq;

namespace Chat.Logic
{
    public static class ServiceExtentions
    {
        /// <summary>
        /// Регистрация IChatService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterChatService(this IServiceCollection services)
        {
            var mock = new Mock<IChatService>();

            services.AddScoped<IChatService>(_ => mock.Object);
            return services;
        }
    }
}
