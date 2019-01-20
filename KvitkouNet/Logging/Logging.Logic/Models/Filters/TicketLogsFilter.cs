using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class TicketLogsFilter : BaseLogFilter
    {
		public string TicketName { get; set; }
	}
}
