﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq;
using UserSettings.Data;
using UserSettings.Data.Context;
using UserSettings.Data.Faker;
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

			var mock = new Mock<IUserSettingsService>();
			services.AddScoped(_ => mock.Object);
			services.AddScoped<IValidator, AccountValidator>();
			services.AddScoped<IValidator, ProfileValidator>();
			services.AddScoped<IUserSettingsService, UserSettingsService>();
			services.AddScoped<ISettingsRepo, SettingsRepo>();
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<SettingsProfile>();
				cfg.AddProfile<AccountProfile>();
				cfg.AddProfile<ProfileProfile>();
			});

			return services;
		}

		public static IServiceCollection RegisterDataBase(this IServiceCollection services)
		{
			services.AddDbContext<SettingsContext>(
				opt => opt.UseSqlite(connectionString: "DataSource=./Database.db"));

			
			return services;
		}
	}
}
