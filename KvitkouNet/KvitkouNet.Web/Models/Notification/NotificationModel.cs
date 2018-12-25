using KvitkouNet.Logic.Common.Models.Notification.Enums;

namespace KvitkouNet.Web.Models.Notification
{
	/// <summary>
	/// Модель уведомления
	/// </summary>
	public class NotificationModel
	{
		/// <summary>
		/// Заголовок уведомления
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст уведомления
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Тип уведомления
		/// </summary>
		public NotificationType Type { get; set; }
	}
}
