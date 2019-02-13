using System.Linq;
using Dashboard.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Dashboard.Data.Fakers;
using DashboardMicroService;

namespace Dashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o = new DbContextOptionsBuilder<DashboardContext>();
            o.UseSqlite("Data Source=./NewsDatabase.db");

            using (var context = new DashboardContext(o.Options))
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();
                if (!context.News.Any())
                {
                    context.News.AddRange(NewsFaker.Generate(5));
                    context.SaveChanges();
                }

            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
