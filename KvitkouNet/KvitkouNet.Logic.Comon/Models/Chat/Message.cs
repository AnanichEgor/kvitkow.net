﻿using System;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Id комнаты в которой было отправлено сообщение
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// Id пользователя кто отправил сообщение
        /// </summary>
        public string UserId { get; set; }

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
