using System;
using KvitkouNet.Logic.Common.Enums;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Модель записи в лог о действии с билетом
    /// </summary>
    public class TicketActionLogEntry
    {
        public long Id { get; set; }

        /// <summary>
        /// Билета, над которым совершено действие
        /// </summary>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// Пользователь-владелец билета
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// Тип действия с билетом
        /// </summary>
        public TicketAction Action { get; set; }

        /// <summary>
        /// Содержимое действия
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата совершения действия
        /// </summary>
        public DateTime Created { get; set; }
    }
}
