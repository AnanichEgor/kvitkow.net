using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.Chat
{
    /// <summary>
    /// Модель сообщения в чате, для пользователя который offline
    /// </summary>
    public class OfflineChatMessage
    {
        /// <summary>
        /// Имя пользователя который отправил сообщение
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Время отправки.
        /// </summary>
        public DateTime SendedTime { get; set; }

    }
}
