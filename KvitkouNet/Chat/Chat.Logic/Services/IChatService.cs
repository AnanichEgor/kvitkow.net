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

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <returns></returns>
        Task AddRoom(Room room, string userId);

        /// <summary>
        /// Получение доступных комнат
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetRooms(string userId);

        /// <summary>
        /// Поиск комнаты по названию
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> SearchRoom(string template);

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Message>> GetMessages(string roomId, string userId);

        /// <summary>
        /// Поиск сообщения в комнате
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Message>> SearchMessage(string roomId, string template);

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        Task AddMessage(Message message, string roomId);

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task EditMessage(Message message, string roomId);

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <returns></returns>
        Task DeleteMessage(string roomId, string messageId);

        /// <summary>
        /// Проставить признак прочитанного сообщения
        /// </summary>
        Task EditSettingIsReeadForMessage(string roomId, string messageId);
    }
}
