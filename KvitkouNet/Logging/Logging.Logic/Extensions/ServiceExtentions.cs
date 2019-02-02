using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using KvitkouNet.Messages.Logging;
using Logging.Data;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Logging.Logic.Services;
using Logging.Logic.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Logic.Extensions
{
	public static class ServiceExtentions
	{
		/// <summary>
		/// Регистрация сервисов
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IAccountLogService, AccountLogService>();
			services.AddScoped<IDealLogService, DealLogService>();
			services.AddScoped<IErrorLogService, ErrorLogService>();
			services.AddScoped<IPaymentLogService, PaymentLogService>();
			services.AddScoped<ISearchLogService, SearchLogService>();
			services.AddScoped<ITicketLogService, TicketLogService>();

			return services;
		}

		public static IServiceCollection RegisterValidators(this IServiceCollection services)
		{
			services.AddScoped<IValidator<ErrorLogsFilter>, ErrorLogsFilterValidator>();

			return services;
		}

		/// <summary>
		/// Регистрация LoggingDbContext
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterDbContext(this IServiceCollection services)
		{
			const string connectionString = "Data Source=Logs.db";
			services.AddDbContext<LoggingDbContext>(opt => opt.UseSqlite(connectionString));
			return services;
		}

	    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
	    {
	        var assemblyNamesToScan = Assembly
	            .GetEntryAssembly()
	            .GetReferencedAssemblies()
	            .Where(an => an.FullName.StartsWith("Logging", StringComparison.OrdinalIgnoreCase))
	            .Select(an => an.FullName);

	        services.AddAutoMapper(cfg => cfg.AddProfiles(assemblyNamesToScan));

	        return services;
	    }
	}
}
