﻿using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель для записи в лог информации о платежах.
    /// <para>В случае неудачи причина пишется в поле Content класса BaseLogEntry</para>
    /// </summary>
    public class PaymentLogEntryDbModel : Entity<string>
    {
        /// <summary>
        /// Модель платежной транзакции
        /// </summary>
        public string TransactionInfo { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
