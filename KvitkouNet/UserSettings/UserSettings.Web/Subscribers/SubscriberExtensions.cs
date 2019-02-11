using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using KvitkouNet.Messages.UserSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserSettings.Web.Consumers;

namespace UserSettings.Web.Subscribers
{
	public static class SubscriberExtensions
	{

		public static IBus SubscribeAll(this IBus bus, IServiceProvider services)
		{
			bus.SubscribeAsync<UserCreationMessage>("GetUserProfile.Added", msg => services.GetService<IConsumeAsync<UserCreationMessage>>().ConsumeAsync(msg));
			return bus;
		}
		public  static IApplicationBuilder UseSubscriber(this IApplicationBuilder app, string prefix, params Assembly[] assembly)
		{
			var services = app.ApplicationServices.CreateScope().ServiceProvider;

			var lifetime = services.GetService<IApplicationLifetime>();
			var bus = services.GetService<IBus>();

			lifetime.ApplicationStarted.Register(() =>
			{
				var subscriber = new AutoSubscriber(bus, prefix);
				subscriber.Subscribe(assembly);
				subscriber.SubscribeAsync(assembly);
				//bus.SubscribeAll(services);
			});

			lifetime.ApplicationStopped.Register(() => bus.Dispose());

			return app;
		}

		public static IServiceCollection RegisterConsumers(this IServiceCollection services)
		{
			services.AddScoped<IConsumeAsync<UserCreationMessage>, UserProfileConsumer>();
			return services;
		}
	}
}
