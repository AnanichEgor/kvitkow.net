using System;

namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Уведомление
	/// </summary>
	public class Notification
	{
		/// <summary>
		/// Получатель уведомления
		/// </summary>
		public long UserId { get; set; }

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
	}
}