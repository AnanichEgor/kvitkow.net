using System.Net.Http;
using AdminPanel.Logic.Generated.Logging;
using AdminPanel.Logic.Infrastructure;
using AdminPanel.Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdminPanel.Web.Extensions
{
	public static class ServiceExtensions
	{
		/// <summary>
		/// Регистрация IUserService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterUserService(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();

			return services;
		}

		/// <summary>
		/// Регистрация сгенерированного IErrorLog
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterLoggingService(this IServiceCollection services)
		{
			services.AddScoped<IErrorLog>(p => new ErrorLog(new MyTitle(new HttpClient(), true)));

			return services;
		}
	}
}