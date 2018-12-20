using System;
using System.Collections.Generic;
using KvitkouNet.Logic.Common.Models.Chat.Settings;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Chat
    {
        /// <summary>
        /// Пользовательские настройки для чата
        /// </summary>
        public Settings.UserSettings UserSettings { get; set; }

        /// <summary>
        /// Список комнат
        /// </summary>
        public List<Room> Rooms { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public Room MainRoom { get; set; }
    }
}
