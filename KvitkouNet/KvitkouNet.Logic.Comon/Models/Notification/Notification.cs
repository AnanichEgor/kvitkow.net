using System;

namespace KvitkouNet.Logic.Common.Models.Notification
{
	/// <summary>
	/// Уведомление
	/// </summary>
	public class Notification
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
		/// Дата отправки
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Получатель
		/// </summary>
		public string Receiver { get; set; }
	}
}