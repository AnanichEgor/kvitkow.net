using Logging.Data.DbModels.Abstraction;
using Logging.Logic.Common.Enums;

namespace Logging.Data.DbModels
{
    public class TicketDealLogEntryDbModel : Entity<long>
    {
        /// <summary>
        /// Покупатель/получатель билета
        /// </summary>
        public string Reciever { get; set; }

        /// <summary>
        /// Цена билета, т.е. сумма сделки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public DealType Type { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
