using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;

namespace Logging.Web.Subscriber
{
	public class InternalErrorLogConsumer : IConsumeAsync<InternalErrorLogEntryMessage>
	{
		public InternalErrorLogConsumer()
		{
			
		}

		[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		public Task ConsumeAsync(InternalErrorLogEntryMessage message)
		{
			//throw new NotImplementedException("subscription works");
			return Task.CompletedTask;
		}
	}
}