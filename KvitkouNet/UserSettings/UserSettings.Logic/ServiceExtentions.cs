using AutoMapper;
using EasyNetQ;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq;
using UserSettings.Data;
using UserSettings.Data.Context;
using UserSettings.Data.Faker;
using UserSettings.Logic.MappingProfile;
using UserSettings.Logic.Models;
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
			services.RegisterUserServicesData();
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<SettingsProfile>();
				cfg.AddProfile<NotificationsProfile>();
			});
			services.AddScoped<IValidator<Settings>, SettingsValidator>();
			services.AddScoped<IUserSettingsService, UserSettingsService>();
			services.AddScoped<ISettingsRepo, SettingsRepo>();
		
			return services;
		}
	}
}
