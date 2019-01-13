using Notification.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Notification.Logic
{
    public static class ServiceExtentions
    {
		/// <summary>
		/// Регистрация INotificationService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterNotificationService(this IServiceCollection services)
		{
			services.AddScoped(obj => new Mock<INotificationService>().Object);
			return services;
		}
    }
}
