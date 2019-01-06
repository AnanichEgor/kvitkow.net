using Logging.Logic.Common.Enums;
using Logging.Logic.Common.Models.Abstraction;

namespace Logging.Logic.Common.Models
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
