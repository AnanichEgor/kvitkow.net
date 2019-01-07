using Logging.Data.DbModels.Abstraction;
using Logging.Logic.Common.Enums;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель записи в лог о действии с билетом
    /// </summary>
    public class TicketActionLogEntryDbModel : Entity<long>
    {
        /// <summary>
        /// Тип действия с билетом
        /// </summary>
        public TicketAction Action { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
