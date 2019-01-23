using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Logic.Models;

namespace Chat.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Chat
    /// </summary>
    public interface IChatService : IDisposable
    {
        /// <summary>
        /// Получение пользовательских настроек для чата
        /// </summary>
        /// <returns></returns>
        Task<Settings> GetUserSettings(string userId);

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        Task EditUserSettings(string userId, Settings settings);

        /// <summary>
        /// Изменение роли пользователя в чате
        /// </summary>
        Task EditUserRole(string userId, User settings);
    }
}
