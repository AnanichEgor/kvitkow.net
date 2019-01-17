using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Logic.Models.Requests
{
	/// <summary>
	/// Запрос 
	/// </summary>
	public class SendEmailRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SenderEmail { get; set; } 

		/// <summary>
		/// 
		/// </summary>
		public string SenderPassword { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ReceiverName { get; set; } 

		/// <summary>
		/// 
		/// </summary>
		public string ReceiverEmail { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Text { get; set; }

	}
}
