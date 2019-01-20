using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Data.DbModels
{
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
        public List<TicketInfoDb> UserTickets { get; set; }
    }
}
