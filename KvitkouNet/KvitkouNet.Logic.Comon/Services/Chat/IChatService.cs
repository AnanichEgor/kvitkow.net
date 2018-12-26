using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Chat;
using KvitkouNet.Logic.Common.Models.Chat.ChatSettings;


namespace KvitkouNet.Logic.Common.Services.Chat
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
        /// Получение списка прав доступа
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetRooms(string userId);

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Message>> GetMessagesFromTheRoom(string id);

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
        Task EditSettingsForMessage(string roomId, string messageId);

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        Task EditUserSettings(Settings settings);
    }
}
