using System;
using System.Data;
using System.Linq;
using Logging.Data;
using Logging.Data.Fakers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<LoggingDbContext>();
					context.Database.Migrate();
					if (!context.InternalErrorLogEntries.Any())
					{
						context.InternalErrorLogEntries.AddRange(InternalErrorLogEntryFaker.Generate());
						context.SaveChanges();
					}
				}
				catch (Exception)
				{
					throw new DataException("Не удалось засидать базу");
				}
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
