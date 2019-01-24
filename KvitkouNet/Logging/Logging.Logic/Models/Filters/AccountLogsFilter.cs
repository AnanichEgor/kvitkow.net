using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class AccountLogsFilter : BaseLogFilter
    {
		public string UserName { get; set; }
	}
}
