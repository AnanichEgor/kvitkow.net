using System;
using Dashboard.Data.DbModels.DbEnums;

namespace Dashboard.Data.DbModels
{
    public class NewsDb
    {
        /// <summary>
        ///     Id билета
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        ///     Краткое описание события
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Имя пользователя
        /// </summary>
        public UserInfoDb UserInfo { get; set; }

       
        /// <summary>
        ///     Адрес проведения мероприятия
        /// </summary>
        public TicketInfoDb TicketInfo { get; set; }
               

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
    }
}
