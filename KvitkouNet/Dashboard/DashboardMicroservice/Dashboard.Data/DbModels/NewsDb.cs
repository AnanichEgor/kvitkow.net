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
        ///     Имя пользователя
        /// </summary>
        public UserInfoDb FirstName { get; set; }

        /// <summary>
        ///     Фамилия пользователя
        /// </summary>
        public UserInfoDb LastName { get; set; }

        /// <summary>
        ///     Адрес проведения мероприятия
        /// </summary>
        public TicketInfoDb Name { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public TicketInfoDb Price { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public TicketInfoDb LocationEvent { get; set; }

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
