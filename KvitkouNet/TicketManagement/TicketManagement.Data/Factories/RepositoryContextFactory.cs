using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using TicketManagement.Data.Context;
using TicketManagement.Data.Fakes;

namespace TicketManagement.Data.Factories
{
   public class RepositoryContextFactory
    {
        private readonly IConfiguration _configuration;

        public RepositoryContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TicketContext CreateDbContext()
        {
            var connectionString = _configuration.GetValue<string>("connectionString");
            var o = new DbContextOptionsBuilder<TicketContext>();
            o.UseSqlite(connectionString);
            using (var ctx = new TicketContext(o.Options))
            {
                ctx.Database.Migrate();
                if (!ctx.Tickets.Any())
                {
                    ctx.Tickets.AddRange(TicketFaker.Generate(50));
                    ctx.SaveChanges();
                }
            }

            return new TicketContext(o.Options);
        }
    }
}
