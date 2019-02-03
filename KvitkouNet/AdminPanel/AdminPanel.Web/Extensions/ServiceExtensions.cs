using System.Net.Http;
using AdminPanel.Logic.Generated.Logging;
using AdminPanel.Logic.Infrastructure;
using AdminPanel.Logic.Services;
using AdminPanel.Web.Filters;
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
			//services.AddScoped<IUserService, UserService>();

			return services;
		}

		/// <summary>
		/// Регистрация сгенерированного IErrorLog
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterLoggingServices(this IServiceCollection services)
		{
			services.AddScoped<IErrorLog>(p => new ErrorLog(new MyTitle(new HttpClient(), true)));
			services.AddScoped<IAccountLog>(p => new AccountLog(new MyTitle(new HttpClient(), true)));
			services.AddScoped<IPaymentLog>(p => new PaymentLog(new MyTitle(new HttpClient(), true)));
			services.AddScoped<IQueryLog>(p => new QueryLog(new MyTitle(new HttpClient(), true)));
			services.AddScoped<ITicketActionLog>(p => new TicketActionLog(new MyTitle(new HttpClient(), true)));
			services.AddScoped<ITicketDealLog>(p => new TicketDealLog(new MyTitle(new HttpClient(), true)));

			return services;
		}


		public static IServiceCollection RegisterFilters(this IServiceCollection services)
		{
			services.AddScoped<GlobalExceptionFilter>();

			return services;
		}
	}
}