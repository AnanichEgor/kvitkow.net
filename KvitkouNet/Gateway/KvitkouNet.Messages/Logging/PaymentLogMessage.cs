﻿using System;

namespace KvitkouNet.Messages.Logging
{
	/// <summary>
	/// Модель сообщения о платежных операциях
	/// </summary>
	public class PaymentLogMessage
	{
		/// <summary>
		/// Id записи
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Дата логируемого события
		/// </summary>
		public DateTime EventDate { get; set; }

		/// <summary>
		/// Id отправителя денег
		/// </summary>
		public string SenderId { get; set; }

		/// <summary>
		/// Id получателя денег
		/// </summary>
		public string ReciverId { get; set; }

		/// <summary>
		/// Сумма перевода
		/// </summary>
		public decimal Transfer { get; set; }
	}
}