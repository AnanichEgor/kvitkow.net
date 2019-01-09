﻿using System.Collections.Generic;
using System.Linq;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;
using KvitkouNet.Logic.Common.Models.Search;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.Logging;
using KvitkouNet.Logic.Common.Services.Chat;
using KvitkouNet.Logic.Common.Services.Notification;
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

		public static IServiceCollection RegisterNotificationService(this IServiceCollection services)
		{
			services.AddScoped(obj => new Mock<INotificationService>().Object);
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
