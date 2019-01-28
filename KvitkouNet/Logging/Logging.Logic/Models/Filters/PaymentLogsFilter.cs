using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
	public class PaymentLogsFilter : BaseLogFilter
    {
        /// <summary>
        /// Id отправителя денег
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// Id получателя денег
        /// </summary>
        public string ReciverId { get; set; }

        /// <summary>
        /// Сумма перевода
        /// </summary>
        public double? MinTransfer { get; set; }

        /// <summary>
        /// Сумма перевода
        /// </summary>
        public double? MaxTransfer { get; set; }
    }
}
