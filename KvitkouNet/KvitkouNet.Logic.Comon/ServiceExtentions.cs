using System.Collections.Generic;
using System.Linq;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;
using KvitkouNet.Logic.Common.Services.Logging;
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
