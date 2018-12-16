namespace KvitkouNet.Logic.Common.Models.Logging.Abstraction
{
    /// <summary>
    /// Базовый класс для создание доменных моделей записей лога о билетах
    /// </summary>
    internal abstract class BaseTicketLogEntry : BaseLogEntry<int>
    {
        /// <summary>
        /// Билет
        /// </summary>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// Пользователь-владелец билета
        /// </summary>
        public User Owner { get; set; }
    }
}
