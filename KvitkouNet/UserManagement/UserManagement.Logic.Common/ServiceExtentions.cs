using UserManagement.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using FluentValidation;
using UserManagement.Logic.Validators;
using UserManagement.Logic.Models;
using AutoMapper;
using UserManagement.Data.Fakers;
using UserManagement.Data.Context;
using UserManagement.Logic.MappingProfiles;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Logic
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            var o = new DbContextOptionsBuilder<UserContext>();
            o.UseSqlite("Data Source=./UserDatabase.db");

            using (var context = new UserContext(o.Options))
            {
                context.Database.Migrate();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(UserFaker.Generate());
                    context.SaveChanges();
                }
            }
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            services.AddScoped<IValidator<User>, UserValidator>();
            var mock = new Mock<IUserService>();

            services.AddScoped<IUserService>(_ => mock.Object);
            return services;
        }
    }
}
