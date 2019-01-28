using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель для записи в лог информации о платежах
    /// </summary>
    public class PaymentLogEntryDbModel : BaseLogEntryDbModel
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
        public decimal Transfer { get; set; }
    }
}
