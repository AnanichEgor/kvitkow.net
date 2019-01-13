using AdminPanel.Logic.Infrastructure;
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
			services.AddScoped<IUserService, IUserService>();

			return services;
		}
	}
}