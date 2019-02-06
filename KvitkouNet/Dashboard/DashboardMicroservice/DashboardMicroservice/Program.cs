using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DashboardMicroService;
using Dashboard.Data.Fakers;
using Dashboard.Data.Context;

namespace DashboardMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o = new DbContextOptionsBuilder<DashboardContext>();
            o.UseLazyLoadingProxies().UseSqlite("Data Source=./NewsDatabase.db");
            using (var ctx = new DashboardContext(o.Options))
            {
                ctx.Database.Migrate();
                if (!ctx.News.Any())
                {
                    ctx.News.AddRange(NewsFaker.Generate(10));
                    ctx.SaveChanges();
                }
            }

            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
