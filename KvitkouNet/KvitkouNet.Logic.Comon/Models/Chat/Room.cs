using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class Room
    {

        /// <summary>
        /// номер комнаты
        /// </summary>
        public long Id;

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список Users в комнате
        /// </summary>
        public  List<long> UserId;

        /// <summary>
        /// Список сообщений в конате
        /// </summary>
        public List<Message> Messages;
    }
}
