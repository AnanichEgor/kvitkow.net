using Dashboard.Logic.Models.Enums;

namespace Dashboard.Logic.Models
{
    public class News
    {
        /// <summary>
        ///     Краткое описание события
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Имя пользователя
        /// </summary>
        public UserInfo UserInfo { get; set; }
                 
        /// <summary>
        ///     Цена билета
        /// </summary>
        public TicketInfo TicketInfo { get; set; }

        
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
    }
}
