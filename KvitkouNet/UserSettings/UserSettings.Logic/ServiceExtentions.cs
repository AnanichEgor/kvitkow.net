using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq;
using UserSettings.Data.Context;
using UserSettings.Logic.MappingProfile;
using UserSettings.Logic.Services;
using UserSettings.Logic.Validators;

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

			var mock = new Mock<IUserSettingsService>();
			services.AddScoped(_ => mock.Object);
			services.AddScoped<IValidator, AccountValidator>();
			services.AddScoped<IValidator, ProfileValidator>();
			services.AddScoped<IUserSettingsService, UserSettingsService>();
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<AccountProfile>();
				cfg.AddProfile<ProfileProfile>();
				cfg.AddProfile<SettingsProfile>();
			});

			return services;
		}
	}
}
