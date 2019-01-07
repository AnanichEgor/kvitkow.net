﻿using System;
using Notification.Data.Models.Enums;

namespace Notification.Data.Models
{
	/// <summary>
	/// Уведомление
	/// </summary>
	class Notification
	{
		/// <summary>
		/// Id уведомления
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Получатель уведомления
		/// </summary>
		public User User { get; set; }

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

		/// <summary>
		/// Дата отправки
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Отправитель уведомления
		/// </summary>
		/// <remarks>Используется для типов, где необходима информация об отправителе</remarks>
		public User Sender { get; set; }

		/// <summary>
		/// Тип уведомления
		/// </summary>
		public NotificationType Type { get; set; }
	}
}