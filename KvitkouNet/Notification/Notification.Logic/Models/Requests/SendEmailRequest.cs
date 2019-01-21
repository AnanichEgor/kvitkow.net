using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Logic.Models.Requests
{
	/// <summary>
	/// Запрос для отправки сообщения на почту
	/// </summary>
	public class SendEmailRequest
	{
		/// <summary>
		/// Имя отправителя
		/// </summary>
		public string SenderName { get; set; }

		/// <summary>
		/// Почта отправителя
		/// </summary>
		public string SenderEmail { get; set; }

		/// <summary>
		/// Пароль от почты отправителя
		/// </summary>
		public string SenderPassword { get; set; }

		/// <summary>
		/// Имя получателя
		/// </summary>
		public string ReceiverName { get; set; }

		/// <summary>
		/// Почта получателя
		/// </summary>
		public string ReceiverEmail { get; set; }

		/// <summary>
		/// Тема сообщения
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Текст сообщения
		/// </summary>
		/// <remarks>Поддерживает html</remarks>
		public string Text { get; set; }

	}
}
