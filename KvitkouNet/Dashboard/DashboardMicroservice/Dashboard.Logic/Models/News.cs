using Dashboard.Logic.Models.Enums;
using System.Collections.Generic;

namespace Dashboard.Logic.Models
{
    public class News
    {
        /// <summary>
        ///     Id билета
        /// </summary>
        public string NewsId { get; set; }
    
        /// <summary>
        ///     Цена билета
        /// </summary>
        public virtual TicketInfo Ticket { get; set; }
    }
}
