using System.Collections.Generic;
using KvitkouNet.Logic.Common.Models.Security;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Room
    {
        /// <summary>
        /// Id создателя комнаты
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// номер комнаты
        /// </summary>
        public string Id;

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модификатор доступа комнаты
        /// </summary>
        public bool IsPrivat;

        /// <summary>
        /// Доступность комнаты для определенной роли пользователя
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Список Users в комнате
        /// </summary>
        public List<string> UsersId;

        /// <summary>
        /// Список сообщений в конате
        /// </summary>
        public List<Message> Messages;
    }
}
