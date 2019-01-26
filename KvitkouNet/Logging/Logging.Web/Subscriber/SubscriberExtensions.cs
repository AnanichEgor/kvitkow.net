using System.Reflection;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web.Subscriber
{
	public static class SubscriberExtensions
	{
		public static IApplicationBuilder UseSubscriber(this IApplicationBuilder app, string prefix,
			params Assembly[] assembly)
		{
			var services = app.ApplicationServices.CreateScope().ServiceProvider;

			var lifetime = services.GetService<IApplicationLifetime>();
			var bus = services.GetService<IBus>();

			lifetime.ApplicationStarted.Register(() =>
			{
				//var subscriber = new AutoSubscriber(bus, prefix);
				//subscriber.Subscribe(assembly);
				//subscriber.SubscribeAsync(assembly);
				bus.Subscribe<InternalErrorLogEntryMessage>("ErrorLogging.Added",
					msg => services.GetService<IConsumeAsync<InternalErrorLogEntryMessage>>().ConsumeAsync(msg));
				bus.SubscribeAsync<InternalErrorLogEntryMessage>("ErrorLogging.Added",
					msg => services.GetService<IConsumeAsync<InternalErrorLogEntryMessage>>().ConsumeAsync(msg));
			});

			lifetime.ApplicationStopped.Register(() => bus.Dispose());

			return app;
		}
	}
}