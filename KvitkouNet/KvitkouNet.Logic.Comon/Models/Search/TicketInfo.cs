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
        public int TicketId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Category { get; set; }

        //todo: Add other required properties after Ticket model is available and search criteria are clarified.
    }
}
