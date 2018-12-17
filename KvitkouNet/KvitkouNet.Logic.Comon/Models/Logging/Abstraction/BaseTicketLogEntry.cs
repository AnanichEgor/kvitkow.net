﻿using KvitkouNet.Logic.Common.Models.Logging.Mocks;

namespace KvitkouNet.Logic.Common.Models.Logging.Abstraction
{
    /// <summary>
    /// Базовый класс для создание доменных моделей записей лога о билетах
    /// </summary>
    public abstract class BaseTicketLogEntry : BaseLogEntry<long>
    {
        /// <summary>
        /// Билет
        /// </summary>
        public TicketMock Ticket { get; set; }

        /// <summary>
        /// Пользователь-владелец билета
        /// </summary>
        public User.User Owner { get; set; }
    }
}
