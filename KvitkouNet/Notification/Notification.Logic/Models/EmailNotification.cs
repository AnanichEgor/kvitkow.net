namespace KvitkouNet.Logic.Models.Notification
{
	/// <summary>
	/// Уведомление по электронной почте
	/// </summary>
	public class EmailNotification : Notification
	{
		/// <summary>
		/// Отправитель уведомления
		/// </summary>
		public string SenderId { get; set; }

		/// <summary>
		/// Электронный ящик
		/// </summary>
		public string Email { get; set; }
	}
}