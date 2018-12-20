using System;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime Sended { get; set; }
    }
}
