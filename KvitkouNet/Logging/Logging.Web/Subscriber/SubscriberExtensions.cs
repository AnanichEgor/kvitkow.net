using System.Reflection;
using EasyNetQ;
using Logging.Web.Extensions;
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
				bus.SubscribeAllConsumers(services);
			});

			lifetime.ApplicationStopped.Register(() => bus.Dispose());

			return app;
		}
	}
}