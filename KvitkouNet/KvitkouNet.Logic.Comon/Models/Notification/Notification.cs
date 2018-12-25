using System;
using KvitkouNet.Logic.Common.Models.Notification.Enums;

namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Уведомление
	/// </summary>
	public class Notification
	{
		/// <summary>
		/// Id уведомления
		/// </summary>
		public string NotificationId { get; set; }

		/// <summary>
		/// Получатель уведомления
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Заголовок уведомления
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст уведомления
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Дата отправки
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Тип уведомления
		/// </summary>
		public NotificationType Type { get; set; }
	}
}