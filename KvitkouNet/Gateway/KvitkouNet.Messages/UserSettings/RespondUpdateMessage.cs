using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.UserSettings
{
	public class RespondUpdateMessage
	{
		public bool UpdateResult { get; set; }

		public string Message { get; set; } = string.Empty;
	}
}
