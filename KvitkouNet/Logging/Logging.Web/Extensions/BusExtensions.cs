using System;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web.Extensions
{
	/// <summary>
	/// Класс методов расширения для IBus
	/// </summary>
	public static class BusExtensions
	{
		/// <summary>
		/// Подписка всех требуемых IConsumer
		/// </summary>
		/// <param name="bus"></param>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IBus SubscribeAllConsumers(this IBus bus, IServiceProvider services)
		{
			var prefix = "ErrorLogging.Added";
			var internalErrorLogConsumer = services.GetService<IConsumeAsync<InternalErrorLogMessage>>();
			bus.SubscribeAsync<InternalErrorLogMessage>(prefix, msg => internalErrorLogConsumer.ConsumeAsync(msg));
			return bus;
		}
	}
}