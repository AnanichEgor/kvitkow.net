﻿using Logging.Logic.Common.Models.Abstraction;
using Logging.Logic.Common.Models.Mocks;

namespace Logging.Logic.Common.Models
{
	/// <summary>
	/// Модель для записи в лог информации о платежах.
	/// <para>В случае неудачи причина пишется в поле Content класса BaseLogEntry</para>
	/// </summary>
	public class PaymentLogEntry : BaseLogEntry<long>
	{
		/// <summary>
		/// Модель платежной транзакции
		/// </summary>
		public PaymentTransactionMock PaymentTransaction { get; set; }
	}
}
