using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserSettings.Data.Context;
using UserSettings.Data.Faker;

namespace UserSettings.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var o = new DbContextOptionsBuilder<SettingsContext>();
			o.UseSqlite("Data Source=./Database.db");
			using (var ctx = new SettingsContext(o.Options))
			{

				ctx.Database.Migrate();
				if (!ctx.Settings.Any())
				{
					ctx.Settings.AddRange(UserSettingsFaker.Generate(10));
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
