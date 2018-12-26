using KvitkouNet.Logic.Common.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Statistic
{
    public class OwnStatistic
    {
        /// <summary>
        /// Provides total completed offers count
        /// Предоставляет общее количество совершенных сделок
        /// </summary>
        public IEnumerable<Offer> TotalOffers { get; set; }

        /// <summary>
        /// Provides total sell tickets count
        /// Предоставляет общее количество Проданных билетов
        /// </summary>
        //public IEnumerable<Ticket.Ticket> RealisedTickets { get; set; }

        ///// <summary>
        ///// Provides total tickets, which have been presented
        ///// Предоставляет общее количество билетов, которые были подарены
        ///// </summary>
        //public IEnumerable<Ticket.Ticket> DonatedTickets { get; set; }

        /// <summary>
        /// Provides users, who get in the black list
        /// Предоставляет общее количество пользователей, попавший в собственный черный список
        /// </summary>
        public IDictionary<User, string> BannedUsers { get; set; }
    }
}
