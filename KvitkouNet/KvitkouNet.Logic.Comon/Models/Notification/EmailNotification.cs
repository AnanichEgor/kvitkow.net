namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Уведомление по электронной почте
	/// </summary>
	public class EmailNotification : Notification
	{
		/// <summary>
		/// Отправитель уведомления
		/// </summary>
		public long SenderId { get; set; }

		/// <summary>
		/// Электронный ящик
		/// </summary>
		public string Email { get; set; }
	}
}