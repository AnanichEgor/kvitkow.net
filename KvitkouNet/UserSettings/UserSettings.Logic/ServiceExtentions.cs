using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq;
using UserSettings.Data.Context;
using UserSettings.Logic.MappingProfile;
using UserSettings.Logic.Services;

namespace UserSettings.Logic
{
	public static class ServiceExtentions
	{
		/// <summary>
		/// Регистрация IUserSettingsService
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterUserSettingsService(this IServiceCollection services)
		{
			services.AddDbContext<SettingsContext>(
				opt => opt.UseSqlite(connectionString: "DataSource=./Database.db"));

			var o = new DbContextOptionsBuilder<SettingsContext>();
			o.UseSqlite("Data Source=./Database.db");

			using (var context = new SettingsContext(o.Options))
			{
				context.Database.Migrate();
				if (context.Settings.Any())
				{
					context.SaveChanges();
				}
			}
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<AccountProfile>();
				cfg.AddProfile<ProfileProfile>();
				cfg.AddProfile<SettingsProfile>();
			});

			var mock = new Mock<IUserSettingsService>();
			services.AddScoped<IUserSettingsService>(_ => mock.Object);
			return services;
		}
	}
}
