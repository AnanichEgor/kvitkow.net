﻿using System;
//using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Enums;
using System.Collections.Generic;
//using KvitkouNet.Logic.Common.Models.Tickets;

namespace KvitkouNet.Logic.Common.Models.PaymentManagement
{
    /// <summary>
    /// Provides payment`s data
    /// </summary>
    class Payment
    {
        //User Customer { get; set; }
        //User Recepient { get; set; }
        PaymentTransactionStatus Transaction { get; set; }
        //ICollection<Ticket> Tickets { get; set; }
    }
}
