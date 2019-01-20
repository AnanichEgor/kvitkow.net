using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель записи в лог о действии с билетом
    /// </summary>
    public class TicketActionLogEntryDbModel : BaseLogEntry
    {
        /// <summary>
        /// Тип действия с билетом
        /// </summary>
        public int Type { get; set; }
    }
}
