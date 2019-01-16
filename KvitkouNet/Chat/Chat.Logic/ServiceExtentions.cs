using AutoMapper;
using Chat.Data.Context;
using Chat.Logic.MappingProfiles;
using Chat.Logic.Models;
using Microsoft.Extensions.DependencyInjection;
using Chat.Logic.Services;
using Chat.Logic.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Chat.Logic
{
    public static class ServiceExtentions
    {
        /// <summary>
        /// Регистрация IChatService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterChatService(this IServiceCollection services)
        {
            services.AddDbContext<ChatContext>(opt => opt.UseSqlite("Data Source=./ChatDatabase.db"));
            services.AddScoped(_ => ChatServiceMock().Object);
            services.AddScoped<IValidator<Room>, RoomValidator>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MessageProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<SettingsProfile>();
                cfg.AddProfile<UserProfile>();
            });
            return services;
        }

        private static Mock<IChatService> ChatServiceMock()
        {
            var ticketServiceMock = new Mock<IChatService>();
            return ticketServiceMock;
        }
    }
}

