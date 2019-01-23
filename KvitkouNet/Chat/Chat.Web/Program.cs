using System.Linq;
using Chat.Data.Context;
using Chat.Logic.Fakers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Chat.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o = new DbContextOptionsBuilder<ChatContext>();
            o.UseSqlite("Data Source=f:\\Git\\kvitkou-net\\KvitkouNet\\Chat\\Chat.Web\\ChatDatabase.db");

            using (var ctx = new ChatContext(o.Options))
            {
                ctx.Database.Migrate();
                if (!ctx.Rooms.Any())
                {
                    ctx.Rooms.AddRange(RoomFaker.Generate(50));
                //    ctx.Users.AddRange(UserFaker.Generate(50));
                    ctx.SaveChanges();
                }
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
