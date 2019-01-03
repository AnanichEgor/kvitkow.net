using System.Linq;
using KvitkouNet.Logic.Common.Models.Search;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.Chat;
using KvitkouNet.Logic.Common.Services.Search;
using KvitkouNet.Logic.Common.Services.Security;
using KvitkouNet.Logic.Common.Services.Tickets;
using KvitkouNet.Logic.Common.Services.User;
using KvitkouNet.Logic.Common.Services.UserSettings;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace KvitkouNet.Logic.Common
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            var mock = new Mock<IUserService>();

            services.AddScoped<IUserService>(_ => mock.Object);
            services.AddScoped<ISearchUserService>(_ => GetUserSearchMock().Object);
            services.AddScoped<ISearchTicketService>(_ => GetTicketSearchMock().Object);
            return services;
        }

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

        private static Mock<ISearchUserService> GetUserSearchMock()
        {
            var mock = new Mock<ISearchUserService>();
            var result = new SearchResult<UserInfo>
            {
                Items = Enumerable.Empty<UserInfo>(),
                Total = 10
            };
            mock.Setup(service => service.Search(It.IsAny<UserSearchRequest>())).ReturnsAsync(result);

            return mock;
        }

        private static Mock<ISearchTicketService> GetTicketSearchMock()
        {
            var mock = new Mock<ISearchTicketService>();
            var result = new SearchResult<TicketInfo>
            {
                Items = Enumerable.Empty<TicketInfo>(),
                Total = 10
            };
            mock.Setup(service => service.Search(It.IsAny<TicketSearchRequest>())).ReturnsAsync(result);

            return mock;
        }

		public static IServiceCollection RegisterNotificationService(this IServiceCollection services)
		{
			services.AddScoped(obj => new Mock<INotificationService>().Object);
			return services;
		}

        /// <summary>
        /// Регистрация ITicketService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterTicketService(this IServiceCollection services)
        {
            var mock = new Mock<ITicketService>();
            services.AddScoped(_ => mock.Object);
            return services;
        }
		/// <summary>
		/// Регистрация IUserSettingsService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterUserSettingsService(this IServiceCollection services)
		{
			var mock = new Mock<IUserSettingsService>();
			services.AddScoped<IUserSettingsService>(_ => mock.Object);
			return services;
		}
	}
}
