using System;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime Sended { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
    }
}
