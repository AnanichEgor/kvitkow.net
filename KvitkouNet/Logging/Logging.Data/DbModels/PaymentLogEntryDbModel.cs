using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель для записи в лог информации о платежах.
    /// <para>В случае неудачи причина пишется в поле Content класса BaseLogEntry</para>
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
        public decimal Tranfer { get; set; }
    }
}
