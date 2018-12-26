using KvitkouNet.Logic.Common.Models.PaymentManagement;
//using KvitkouNet.Logic.Common.Models.Ticket;
using KvitkouNet.Logic.Common.Models.UserManagement;
using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Statistic
{
    /// <summary>
    /// Shows offering data, making by User
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Provides the data of person who dealt an offer
        /// </summary>
        public User OfferingPerson { get; set; }

        /// <summary>
        /// Shows tickets, which have been using in the offer 
        /// </summary>
        //public IEnumerable<Ticket.Ticket> Tickets { get; }
        
        /// <summary>
        /// Provides the name of offer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Shows completed transaction
        /// </summary>
        public Transaction Transaction { get; }

        /// <summary>
        /// Provides a date of offer
        /// </summary>
        public DateTime Date { get; set; }
    }
}