
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using StatisticOnline.Data.Context;


namespace StatisticOnline.Logic.Services
{
    public static class ServiceExtentions
    {
        /// <summary>
        /// Добавление WebApiContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            const string connectionString = "Data Source=StatisticOnline.db";
            services.AddDbContext<WebApiContext>(opt => opt.UseSqlite(connectionString));
            return services;
        }
    }
}
