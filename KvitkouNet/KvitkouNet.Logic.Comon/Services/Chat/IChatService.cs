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
        Task<IEnumerable<Message>> SearchMessage(string template, string roomId);

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        Task AddMessage(Message message);

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task<Message> EditMessage(ViewMessage message);

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <returns></returns>
        Task DeleteMessage(string messageId);

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        Task<Settings> EditSettings(Settings settings);
    }
}
