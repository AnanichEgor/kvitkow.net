using System;
using Chat.Data.DbModels.Abstraction;

namespace Chat.Data.DbModels
{
    public class MessageDb : SystemDataDb<string>
    {
        /// <summary>
        /// Id пользователя который отправил сообщение.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Время отправки.
        /// </summary>
        public DateTime SendedTime { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Признак прочитанного сообщения (True - если прочитано).
        /// </summary>
        public bool IsRead { get; set; }

        public string RoomId { get; set; }
        public RoomDb Room { get; set; }
    }
}
