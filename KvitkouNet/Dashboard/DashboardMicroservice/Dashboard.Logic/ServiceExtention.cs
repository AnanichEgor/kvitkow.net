using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Dashboard.Data.Context;
using Dashboard.Data.Repositories;
using Dashboard.Logic.Services;
using Dashboard.Logic.Validators;
using Dashboard.Logic.MappingProfiles;

namespace Dashboard.Logic
{
    public static class ServiceExtentions
    {
        /// <summary>
        ///     Регистрация IDashboardService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDashboardService(this IServiceCollection services)
        {
            services.AddDbContext<DashboardContext>(opt => opt.
                UseLazyLoadingProxies().UseSqlite("Data Source=./NewsDatabase.db"));
            services.AddScoped<IValidator<Models.News>, NewsValidator>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IDashboardService, DashboardService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<NewsProfile>();
                cfg.AddProfile<TicketInfoProfile>();
                cfg.AddProfile<UserInfoProfile>();
            });
            return services;
        }

        private static Mock<IDashboardService> DashboardServiceMock()
        {
            var newsServiceMock = new Mock<IDashboardService>();


            return newsServiceMock;
        }
    }
}