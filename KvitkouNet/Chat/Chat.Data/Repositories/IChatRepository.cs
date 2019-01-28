using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chat.Data.DbModels;
using SQLitePCL;

namespace Chat.Data.Repositories
{
    public interface IChatRepository : IDisposable
    {
        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <returns></returns>
        Task AddRoom(RoomDb room, string userId);

        /// <summary>
        /// Получение доступных комнат
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomDb>> GetRooms(string userId);

        /// <summary>
        /// Поиск комнаты по названию
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomDb>> SearchRoom(string template);

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MessageDb>> GetMessages(string roomId, string userId);

        /// <summary>
        /// Поиск сообщения в комнате
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MessageDb>> SearchMessage(string roomId, string template);

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        Task AddMessage(MessageDb message, string roomId);

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task UpdateMessage(MessageDb message, string roomId);

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <returns></returns>
        Task DeleteMessage(string roomId, string messageId);

        /// <summary>
        /// Проставить признак прочитанного сообщения
        /// </summary>
        Task UpdateSettingIsReeadForMessage(string roomId, string messageId);
    }
}
