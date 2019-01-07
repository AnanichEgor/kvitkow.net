using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    public class PaymentLogEntryDbModel : Entity<long>
    {
        /// <summary>
        /// Модель платежной транзакции
        /// </summary>
        public string TransactionInfo { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
