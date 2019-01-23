using System.Diagnostics;
using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Logic.Common.Messages.Logging;
using Logging.Logic.Models;

namespace Logging.Web.Subscriber
{
	public class InternalErrorLogConsumer : IConsumeAsync<InternalErrorLogEntryMessage>
	{
		//private readonly ILoggingService _loggingService;
		//
		//public InternalErrorLogConsumer(ILoggingService loggingService)
		//{
		//	_loggingService = loggingService;
		//}

		//[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		//public Task ConsumeAsync(string message)
		//{
		//	Debug.WriteLine("123123123");
		//	throw new System.NotImplementedException();
		//}


		//[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		//public async Task ConsumeAsync(InternalErrorLogEntry entry)
		//	=> await _loggingService.AddErrorLogAsync(entry);
		//[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging")]
		//public Task Consume(byte[] message)
		//{
		//	Debug.WriteLine("111111111111111111111111111111111");
		//	return Task.CompletedTask;
		//}

		[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		public Task ConsumeAsync(InternalErrorLogEntryMessage message)
		{
			Debug.WriteLine("111111111111111111111111111111111");
			return Task.CompletedTask;
		}
	}
}