using System;
using KvitkouNet.Logic.Common.Enums;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Запись в лог об операции обмена/продажи билета
    /// </summary>
    public class TicketDealLogEntry
    {
        public long Id { get; set; }

        /// <summary>
        /// Билет, по которому произошла сделка
        /// </summary>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// Владелец билета
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// Покупатель/получатель билета
        /// </summary>
        public User Reciever { get; set; }

        /// <summary>
        /// Цена билета, т.е. сумма сделки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public DealType Type { get; set; }

        /// <summary>
        /// Дата сделки
        /// </summary>
        public DateTime Created { get; set; }
    }
}
