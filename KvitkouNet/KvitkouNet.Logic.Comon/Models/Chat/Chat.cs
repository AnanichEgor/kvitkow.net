using System;
using System.Collections.Generic;
using KvitkouNet.Logic.Common.Models.Chat.ChatSettings;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Chat
    {
        /// <summary>
        /// Пользовательские настройки для чата
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// Список комнат
        /// </summary>
        public List<Room> Rooms { get; set; }

    }
}
