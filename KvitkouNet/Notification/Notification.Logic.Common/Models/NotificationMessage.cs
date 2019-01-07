using KvitkouNet.Logic.Common.Models.Notification.Enums;

namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Сообщение уведомления
	/// </summary>
	public class NotificationMessage
	{
		/// <summary>
		/// Заголовок уведомления
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст уведомления
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Строгость уведомления
		/// </summary>
		public Severity Severity { get; set; }
	}	
}
