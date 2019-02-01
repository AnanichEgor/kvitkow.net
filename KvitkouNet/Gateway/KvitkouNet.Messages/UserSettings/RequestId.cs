using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.UserSettings
{
	public class RequestId
	{
		public string Id { get; private set; }
		public RequestId(string id)
		{
			Id = id;
		}
	}
}
