﻿using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель записи в лог о сделке по билету
    /// </summary>
    public class TicketDealLogEntryDbModel : Entity<string>
    {
        /// <summary>
        /// Покупатель/получатель билета
        /// </summary>
        public string Reciever { get; set; }

        /// <summary>
        /// Цена билета, т.е. сумма сделки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
