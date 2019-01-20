using System.Collections.Generic;
using FluentValidation;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Logging.Logic.Services;
using Logging.Logic.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Logging.Logic.Extensions
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
			services.AddScoped<ILoggingService, LoggingService>();
			return services;
		}

		public static IServiceCollection RegisterValidators(this IServiceCollection services)
		{
			services.AddScoped<IValidator<ErrorLogsFilter>, ErrorLogsFilterValidator>();
			return services;
		}

		/// <summary>
		/// Добавление LoggingDbContext
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddDbContext(this IServiceCollection services)
		{
			const string connectionString = "Data Source=Logs.db";
			services.AddDbContext<LoggingDbContext>(opt => opt.UseSqlite(connectionString));
			return services;
		}

		private static Mock<ILoggingService> GetLoggingServiceMock()
		{
			var loggingServiceMock = new Mock<ILoggingService>();

			return loggingServiceMock;
		}
	}
}
