using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSettings.Web.Consumers
{
	public class UserProfileConsumer : IConsumeAsync<UserProfileMessage>
	{
		public Task ConsumeAsync(UserProfileMessage message)
		{
			return null;
		}
	}
}
