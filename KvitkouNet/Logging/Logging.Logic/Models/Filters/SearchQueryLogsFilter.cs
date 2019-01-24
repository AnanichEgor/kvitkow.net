using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class SearchQueryLogsFilter : BaseLogFilter
    {
		public string UserName { get; set; }
	}
}
