﻿using System;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime Sended { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Massage { get; set; }
    }
}
