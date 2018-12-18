using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Search
{
    /// <summary>
    /// Contains minimal information about ticket indexed by Elasticsearch
    /// </summary>
    public class TicketInfo
    {
        /// <summary>
        /// Gets or sets the ticket identifier.
        /// </summary>
        public int TicketId { get; set; }
        
        /// <summary>
        /// Gets or sets the name of ticket.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the city where the event will be held.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the category of the event.
        /// </summary>
        public string Category { get; set; }

        //todo: Add other required properties after Ticket model is available and search criteria are clarified.
    }
}
