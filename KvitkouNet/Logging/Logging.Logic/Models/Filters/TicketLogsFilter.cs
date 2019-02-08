using Logging.Data.Enums;
using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class TicketLogsFilter : BaseLogFilter
    {
        /// <summary>
        /// Id билета
        /// </summary>
		public string TicketId { get; set; }

        /// <summary>
        /// Название билета
        /// </summary>
		public string TicketName { get; set; }

        /// <summary>
        /// Описание и дополнительное содержимое действия
        /// </summary>
		public string Description { get; set; }

        /// <summary>
        /// Тип действия с билетом
        /// </summary>
        public TicketActionType ActionType { get; set; }
    }
}
