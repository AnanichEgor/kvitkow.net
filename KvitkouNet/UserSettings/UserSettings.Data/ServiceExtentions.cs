using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSettings.Data.Context;

namespace UserSettings.Data
{
	public static class ServiceExtentions
	{
		public static IServiceCollection RegisterUserServicesData(this IServiceCollection services)
		{
			services.AddDbContext<SettingsContext>(
				opt => opt.UseSqlite(connectionString: "DataSource=./Database.db"));
			var o = new DbContextOptionsBuilder<SettingsContext>();
			o.UseSqlite("DataSource=./Database.db");
			using (var ctx = new SettingsContext(o.Options))
			{
				ctx.Database.Migrate();
				if (!ctx.Settings.Any())
				{
					ctx.SaveChanges();
				}
			}
			return services;
		}
	}
}
