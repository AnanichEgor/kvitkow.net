using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Ticket
{
    public class Ticket
    {
        public bool Free { get; set; }

        public string Name { get; set; }

        public int TicketId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Date { get; set; }

        public double Price { get; set; }

        public string Properties { get; set; }

        public string SellerPhone { get; set; }

        public string SellerAdress { get; set; }

        public string PaymentSystems { get; set; }

        public string TimeActual { get; set; }

        public string TypeEvent { get; set; }

        public string EventLink { get; set; }
    }
}
