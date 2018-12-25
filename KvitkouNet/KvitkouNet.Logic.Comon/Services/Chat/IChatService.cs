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
        Task<Settings> GetUserSettings(int userId);

        /// <summary>
        /// Получение списка прав доступа
        /// </summary>
        /// <returns></returns>
        //Task<IEnumerable<Room>> GetRooms(int userId);

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        /// <returns></returns>
        Task<Settings> GetMessagesFromTheRoom(string name);

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
        //Task<Settings> EditMessage(ViewMessage message);

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <returns></returns>
        Task<Settings> DeleteMessage(string messageId);

        /// <summary>
        /// Изменение цвета фона чата
        /// </summary>
        Task<Settings> EditSettings(Settings settings);
    }
}
