using System.Collections.Generic;

namespace TicketManagement.Data.DbModels
{
    /// <summary>
    ///     Вспомогательный класс пользователя для тикета
    /// </summary>
    public class UserInfoDb
    {
        /// <summary>
        ///     Id юзера
        /// </summary>
        public string UserInfoDbId { get; set; }

        /// <summary>
        ///     Имя юзера
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Фамилия юзера
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the user rating.
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        ///     Список билетов пользователя
        /// </summary>
        public List<TicketDb> UserTickets { get; set; }
    }
}