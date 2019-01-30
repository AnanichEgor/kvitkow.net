using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;
using Logging.Web.Subscriber;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterConsumers(this IServiceCollection services)
		{
			services.AddScoped<IConsumeAsync<InternalErrorLogMessage>, InternalErrorLogConsumer>();
			return services;
		}
	}
}