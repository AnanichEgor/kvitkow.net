using Dashboard.Logic.Models.Enums;

namespace Dashboard.Logic.Models
{
    public class News
    {
        /// <summary>
        ///     Имя пользователя
        /// </summary>
        public UserInfo FirstName { get; set; }

        /// <summary>
        ///     Фамилия пользователя
        /// </summary>
        public UserInfo LastName { get; set; }

        /// <summary>
        ///     Адрес проведения мероприятия
        /// </summary>
        public TicketInfo Name { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public TicketInfo Price { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public TicketInfo LocationEvent { get; set; }

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
