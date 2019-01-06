using Microsoft.Extensions.DependencyInjection;
using Moq;
using UserSettings.Logic.Common.Services;

namespace UserSettings.Logic.Common
{
	public static class ServiceExtentions
	{
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
