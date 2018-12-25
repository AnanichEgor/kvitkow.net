using System.Collections.Generic;

namespace KvitkouNet.Web.Models.Notification
{
	/// <summary>
	/// Модель для массового добавления уведомлений
	/// </summary>
	public class NotificationBulkModel
	{
		/// <summary>
		/// ИД пользователей
		/// </summary>
		public IEnumerable<string> UserIds { get; set; }

		/// <summary>
		/// Уведомление
		/// </summary>
		public NotificationModel Notification { get; set; }
	}
}
