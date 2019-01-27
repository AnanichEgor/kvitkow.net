using System;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web.Extensions
{
	public static class BusExtensions
	{
		public static IBus SubscribeAllConsumers(this IBus bus, IServiceProvider services)
		{
			var prefix = "ErrorLogging.Added";
			var internalErrorLogConsumer = services.GetService<IConsumeAsync<InternalErrorLogEntryMessage>>();
			bus.SubscribeAsync<InternalErrorLogEntryMessage>(prefix, msg => internalErrorLogConsumer.ConsumeAsync(msg));
			return bus;
		}
	}
}