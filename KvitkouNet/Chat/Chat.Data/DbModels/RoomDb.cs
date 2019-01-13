using System;
using System.Collections.Generic;
using System.Text;
using Chat.Data.DbModels.Abstraction;

namespace Chat.Data.DbModels
{
    public class RoomDb : SystemDataDb<string>
    {
        /// <summary>
        /// Id создателя комнаты.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Название комнаты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модификатор доступа комнаты.
        /// </summary>
        public bool IsPrivat { get; set; }

        /// <summary>
        /// Список Users в комнате.
        /// </summary>
        public List<UserDb> Users;

        /// <summary>
        /// Список сообщений в конате.
        /// </summary>
        public List<MessageDb> Messages;
    }

}
