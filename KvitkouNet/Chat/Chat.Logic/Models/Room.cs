using System.Collections.Generic;

namespace Chat.Logic.Models
{
    public class Room
    {
        /// <summary>
        /// Id комнаты.
        /// </summary>
        public string Id { get; set; }

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
        public List<User> Users;

        /// <summary>
        /// Список сообщений в конате.
        /// </summary>
        public List<Message> Messages;
    }
}
