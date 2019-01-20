using Notification.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Notification.Logic.Services.NotificationService;
using Notification.Logic.Services.EmailNotificationService;

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

		/// <summary>
		/// Регистрация IEmailNotificationService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterEmailNotificationService(this IServiceCollection services)
		{
			services.AddScoped<IEmailNotificationService, EmailNotificationService>();
			return services;
		}

		public static IServiceCollection RegisterEmailSenderService(this IServiceCollection services)
		{
			services.AddScoped<IEmailSenderService, IEmailSenderService>();
			return services;
		}
    }
}
