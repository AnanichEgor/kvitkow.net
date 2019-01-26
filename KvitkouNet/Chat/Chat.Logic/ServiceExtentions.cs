using AutoMapper;
using Chat.Data.Context;
using Chat.Data.Helpers;
using Chat.Data.Repositories;
using Chat.Logic.MappingProfiles;
using Chat.Logic.Models;
using Microsoft.Extensions.DependencyInjection;
using Chat.Logic.Services;
using Chat.Logic.Validators;
using FluentValidation;

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
            services.AddScoped<IChatService, ChatService>();
            return services;
        }

        /// <summary>
        /// Регистрация IRoomService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRoomService(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IValidator<Room>, RoomValidator>();
            return services;
        }

        /// <summary>
        /// Регистрация DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ChatContext>(new RegisterContextHelper().GetOptionsBuilder());
            return services;
        }

        /// <summary>
        /// Регистрация IChatRepository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterChatRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IChatRepository, ChatRepository>();
            return services;
        }

        /// <summary>
        /// Регистрация AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MessageProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<SettingsProfile>();
                cfg.AddProfile<UserProfile>();
            });
            return services;
        }
    }
}

