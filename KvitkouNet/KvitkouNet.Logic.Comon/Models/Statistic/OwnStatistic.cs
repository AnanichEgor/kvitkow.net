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
        /// </summary>
        public IEnumerable<Offer> TotalOffers { get; set; }

        /// <summary>
        /// Provides total sell tickets count
        /// </summary>
        public IEnumerable<Ticket.Ticket> RealisedTickets { get; set; }

        /// <summary>
        /// Provides total tickets, which have been presented
        /// </summary>
        public IEnumerable<Ticket.Ticket> DonatedTickets { get; set; }

        /// <summary>
        /// Provides users, who get in the black list
        /// </summary>
        public IDictionary<User, string> BannedUsers { get; set; }
    }
}
