﻿using System.Collections.Generic;
using Chat.Logic.Models.ChatSettings;

namespace Chat.Logic.Models
{
    public class Chat
    {
        /// <summary>
        /// Пользовательские настройки для чата.
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// Список комнат.
        /// </summary>
        public List<Room> Rooms { get; set; }

    }
}
