using UserManagement.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using FluentValidation;
using UserManagement.Logic.Validators;
using UserManagement.Logic.Models;
using AutoMapper;
using UserManagement.Logic.MappingProfiles;
using UserManagement.Data;

namespace UserManagement.Logic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            services.RegisterUserServicesData();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ForViewModelProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<ProfileProfile>();

            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<UserRegisterModel>, UserRegisterValidator>();
            //services.AddScoped<IValidator<User>, UserValidator>();
            //services.AddScoped<IValidator<Account>, AccountValidator>();
            return services;
        }
    }
}
