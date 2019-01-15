using Notification.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Notification.Data.Context;
using Microsoft.EntityFrameworkCore;

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
			services.AddScoped<INotificationService, NotificationService>();
			return services;
		}
    }
}
