using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.Context;
using TicketManagement.Data.Fakes;

namespace TicketManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o = new DbContextOptionsBuilder<TicketContext>();
            o.UseSqlite("Data Source=./TicketDatabase.db");
            using (var ctx = new TicketContext(o.Options))
            {
                
                ctx.Database.Migrate();
                if (!ctx.Tickets.Any())
                {
                    ctx.Tickets.AddRange(TicketFaker.Generate(50));
                    ctx.SaveChanges();
                }
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}