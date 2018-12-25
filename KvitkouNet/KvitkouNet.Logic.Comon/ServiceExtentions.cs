using System.Collections.Generic;
using System.Linq;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;
using KvitkouNet.Logic.Common.Models.Search;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.Logging;
using KvitkouNet.Logic.Common.Services.Search;
using KvitkouNet.Logic.Common.Services.Security;
using KvitkouNet.Logic.Common.Services.User;
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
	    /// Регистрация ILoggingService
	    /// </summary>
	    /// <param name="services"></param>
	    /// <returns></returns>
	    public static IServiceCollection RegisterLoggingService(this IServiceCollection services)
	    {
            services.AddScoped(_ => GetLoggingServiceMock().Object);

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

        private static Mock<ILoggingService> GetLoggingServiceMock()
        {
            var loggingServiceMock = new Mock<ILoggingService>();

            loggingServiceMock
                .Setup(_ => _.GetAccountLogsAsync(It.IsAny<AccountLogsFilterDto>()))
                .ReturnsAsync(new List<AccountLogEntry>());

            loggingServiceMock
                .Setup(_ => _.GetErrorLogsAsync(It.IsAny<ErrorLogsFilterDto>()))
                .ReturnsAsync(new List<InternalErrorLogEntry>());

            loggingServiceMock
                .Setup(_ => _.GetPaymentLogsAsync(It.IsAny<PaymentLogsFilterDto>()))
                .ReturnsAsync(new List<PaymentLogEntry>());

            loggingServiceMock
                .Setup(_ => _.GetSearchQueryLogsAsync(It.IsAny<SearchQueryLogsFilterDto>()))
                .ReturnsAsync(new List<SearchQueryLogEntry>());

            loggingServiceMock
                .Setup(_ => _.GetSearchQueryLogsAsync(It.IsAny<SearchQueryLogsFilterDto>()))
                .ReturnsAsync(new List<SearchQueryLogEntry>());

            return loggingServiceMock;
        }
    }
}
