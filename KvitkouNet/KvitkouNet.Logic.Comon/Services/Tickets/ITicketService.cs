using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models;
using Microsoft.AspNetCore.Mvc;


namespace KvitkouNet.Logic.Common.Services.Ticket
{
    interface ITicketService: IDisposable

    {
        Task<string> Add(Ticket ticket);
    }
}
