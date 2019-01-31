using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Data.DbModels
{
    /// <summary>
    ///     Класс описания доменной модели билета
    /// </summary>
    public class TicketInfoDb
    {
        /// <summary>
        ///     Id билета
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        ///     Название билета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Адрес проведения мероприятия
        /// </summary>
        public string LocationEvent { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public decimal Price { get; set; }


        /// <summary>
        ///     Телефон продавца
        /// </summary>
        public string SellerPhone { get; set; }

        /// <summary>
        ///     Ссылка на мероприятие
        /// </summary>
        public string EventLink { get; set; }
    }
}
