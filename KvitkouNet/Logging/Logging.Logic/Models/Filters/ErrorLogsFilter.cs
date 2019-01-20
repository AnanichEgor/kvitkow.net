using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class ErrorLogsFilter : BaseLogFilter
    {
		public string ExceptionTypeName { get; set; }
	}
}
