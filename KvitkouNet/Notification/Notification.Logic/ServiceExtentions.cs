using Notification.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Notification.Data.Context;
using Notification.Data.Helpers;
using Notification.Logic.Services.NotificationService;
using Notification.Logic.Services.EmailNotificationService;
using Notification.Logic.Services.EmailSenderService;

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

		/// <summary>
		/// Регистрация IEmailSenderService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterEmailSenderService(this IServiceCollection services)
		{
			services.AddScoped<IEmailSenderService, EmailSenderService>();
			return services;
		}

		/// <summary>
		/// Регистрация NotificationContext
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterNotificationContext(this IServiceCollection services)
		{
			services.AddDbContext<NotificationContext>(new RegisterContextHelper().GetOptionsBuilder());
			return services;
		}
    }
}
