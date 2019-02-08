using System;
using System.Collections.Generic;
using System.Text;

namespace UserSettings.Data.DbModels
{
	public class NotificationDb
	{

		public int Id { get; set; }

		public bool IsLikeMyTicket { get; set; }

		public bool IsWantBuy { get; set; }

		public bool IsOtherNotification { get; set; }
	}
}
