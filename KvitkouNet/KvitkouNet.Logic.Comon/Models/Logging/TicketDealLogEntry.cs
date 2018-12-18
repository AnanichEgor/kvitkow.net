using KvitkouNet.Logic.Common.Enums;
using KvitkouNet.Logic.Common.Models.Logging.Abstraction;
using KvitkouNet.Logic.Common.Models.UserManagement;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Модель записи в лог о сделке по билету
    /// </summary>
    public class TicketDealLogEntry : BaseTicketLogEntry
    {
        /// <summary>
        /// Покупатель/получатель билета
        /// </summary>
        public User Reciever { get; set; }

        /// <summary>
        /// Цена билета, т.е. сумма сделки
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public DealType Type { get; set; }
    }
}
