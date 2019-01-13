namespace KvitkouNet.Logic.Models.Notification
{
	/// <summary>
	/// уведомление для пользователя
	/// </summary>
	public class UserNotification : Notification
	{
		/// <summary>
		/// Отметка для прочитанных уведомлений
		/// </summary>
		public bool IsClosed { get; set; }
	}
}
