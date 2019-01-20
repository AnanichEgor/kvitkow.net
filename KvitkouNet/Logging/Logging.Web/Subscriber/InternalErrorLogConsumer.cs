using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;

namespace Logging.Web.Subscriber
{
	public class InternalErrorLogConsumer : IConsumeAsync<InternalErrorLogEntry>
	{
		private readonly IErrorLogService _loggingService;

		public InternalErrorLogConsumer(IErrorLogService loggingService)
		{
			_loggingService = loggingService;
		}

		[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		public async Task ConsumeAsync(InternalErrorLogEntry entry)
			=> await _loggingService.AddLogAsync(entry);
	}
}