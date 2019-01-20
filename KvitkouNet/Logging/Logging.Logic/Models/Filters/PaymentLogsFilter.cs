using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class PaymentLogsFilter : BaseLogFilter
    {
		public string UserName { get; set; }
	}
}
