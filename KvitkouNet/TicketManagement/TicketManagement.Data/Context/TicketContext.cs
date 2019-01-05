using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement.Logic.Common.Models;

namespace TicketManagement.Data.Context
{
    public class TicketContext: DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
       : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
      
    }
}
