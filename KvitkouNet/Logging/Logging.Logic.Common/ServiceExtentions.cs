using System.Collections.Generic;
using Logging.Logic.Common.Dtos;
using Logging.Logic.Common.Models;
using Logging.Logic.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Logging.Logic.Common
{
	public static class ServiceExtentions
	{
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
