using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Chat
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

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
