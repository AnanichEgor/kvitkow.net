using KvitkouNet.Logic.Common.Enums;
using KvitkouNet.Logic.Common.Models.Logging.Abstraction;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Модель записи в лог о действии с билетом
    /// </summary>
    public class TicketActionLogEntry : BaseTicketLogEntry
    {
        /// <summary>
        /// Тип действия с билетом
        /// </summary>
        public TicketAction Action { get; set; }
    }
}
