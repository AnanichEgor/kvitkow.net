namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Уведомление по электронной почте
	/// </summary>
	class EmailNotification : Notification
	{
		/// <summary>
		/// Отправитель
		/// </summary>
		public string Sender { get; set; }

		/// <summary>
		/// Электронный ящик
		/// </summary>
		public string Email { get; set; }
	}
}