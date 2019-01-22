﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Security.Data;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Requests;
using Security.Logic.Services;

namespace Security.Logic
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Регистрация ISecurityService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSecurityService(this IServiceCollection services)
        {
            var mock = new Mock<ISecurityService>();
            services.RegisterSecurityData();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AccessRightProfile>();
                cfg.AddProfile<AccessFunctionProfile>();
            });
            services.AddScoped<ISecurityService>(_ => mock.Object);
            return services;
        }
    }
}
