using System;
using Dashboard.Data.DbModels.DbEnums;

namespace Dashboard.Data.DbModels
{
    public class NewsDb
    {
        /// <summary>
        ///     Id билета
        /// </summary>
        public string NewsId { get; set; }

        /// <summary>
        ///     Краткое описание события
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        ///     Тип мероприятия
        /// </summary>
        public TypeEventTicketDb TypeEvent { get; set; }

        /// <summary>
        ///     Статус новости
        /// </summary>
        public NewsStatusDb Status { get; set; }

        /// <summary>
        ///     Ссылка на мероприятие
        /// </summary>
        public string EventLink { get; set; }

        /// <summary>
        ///     Дата создания билета
        /// </summary>
        public DateTime CreatedDate { get; set; }

        #region Связи между таблицами 
        /// <summary>
        ///     Id пользователя
        /// </summary>
        public virtual UserInfoDb User { get; set; }


        /// <summary>
        ///     Билет на мероприятие
        /// </summary>
        public virtual TicketInfoDb Ticket { get; set; }
        #endregion 
    }
}
