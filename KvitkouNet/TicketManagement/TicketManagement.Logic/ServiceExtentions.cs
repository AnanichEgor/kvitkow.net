using Microsoft.Extensions.DependencyInjection;
using Moq;
using TicketManagement.Logic.Services;

namespace TicketManagement.Logic
{
    public static class ServiceExtentions
    {
        /// <summary>
        ///     Регистрация ITicketService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterTicketService(this IServiceCollection services)
        {
            services.AddScoped(_ => TicketServiceMock().Object);
            return services;
        }

        private static Mock<ITicketService> TicketServiceMock()
        {
            var ticketServiceMock = new Mock<ITicketService>();


            return ticketServiceMock;
        }
    }
}