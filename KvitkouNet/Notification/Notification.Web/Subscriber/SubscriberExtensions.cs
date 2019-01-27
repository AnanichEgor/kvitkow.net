using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Notification.Logic.Services;
using Notification.Logic.Services.EmailNotificationService;

namespace Notification.Web.Subscriber
{
	public static class SubscriberExtensions
	{
		public static IApplicationBuilder UseSubscriber(this IApplicationBuilder app, string prefix, 
			params Assembly[] assembly) 
		{
			var services = app.ApplicationServices.CreateScope().ServiceProvider;

			var lifetime = services.GetService<IApplicationLifetime>();
			var bus = services.GetService<IBus>();			

			var container = new WindsorContainer();
			container.Register(
					Component.For<RegistrationNotificationMessageConsumer>().ImplementedBy<RegistrationNotificationMessageConsumer>(),
					Component.For<IEmailNotificationService>().ImplementedBy<EmailNotificationService>(),
					Component.For<IConfiguration>().Instance(services.GetService<IConfiguration>()));

			lifetime.ApplicationStarted.Register(() =>
			{
				var subscriber = new AutoSubscriber(bus, prefix)
				{
					AutoSubscriberMessageDispatcher = new WindsorMessageDispatcher(container)
				};
				subscriber.Subscribe(assembly);
				subscriber.SubscribeAsync(assembly);
			});

			lifetime.ApplicationStopped.Register(() => bus.Dispose());

			return app;
		}
	}
}
