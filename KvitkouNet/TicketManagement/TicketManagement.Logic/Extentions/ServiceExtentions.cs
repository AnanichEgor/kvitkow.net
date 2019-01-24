using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Data.Context;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic.MappingProfiles;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Services;
using TicketManagement.Logic.Validators;

namespace TicketManagement.Logic.Extentions
{
    /// <summary>
    ///     Сервис для регистрации сущностей в di
    /// </summary>
    public static class ServiceExtentions
    {
        /// <summary>
        ///     Регистрация ITicketService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterTicketService(this IServiceCollection services)
        {
            services.AddDbContext<TicketContext>(opt => opt.UseSqlite("Data Source=./TicketDatabase.db"));
            services.AddScoped<IValidator<Ticket>, TicketValidator>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<Data.DbModels.Page<TicketDb>>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TicketProfile>();
                cfg.AddProfile<AddressProfile>();
                cfg.AddProfile<UserInfoProfile>();
            });
            return services;
        }
    }
}