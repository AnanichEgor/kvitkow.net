using Dashboard.Logic.Models.Enums;
using System.Collections.Generic;

namespace Dashboard.Logic.Models
{
    public class News
    {
        /// <summary>
        ///     Краткое описание события
        /// </summary>
        public string Description { get; set; }
                
        /// <summary>
        ///     Тип мероприятия
        /// </summary>
        public TypeEventTicket TypeEvent { get; set; }

        /// <summary>
        ///     Статус новости
        /// </summary>
        public NewsStatus Status { get; set; }

        /// <summary>
        ///     Ссылка на мероприятие
        /// </summary>
        public string EventLink { get; set; }

        /// <summary>
        ///     Имя пользователя
        /// </summary>
        public virtual UserInfo User { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public virtual TicketInfo Ticket { get; set; }
    }
}
