using Logging.Data.DbModels.Abstraction;
using Logging.Logic.Common.Enums;

namespace Logging.Data.DbModels
{
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
