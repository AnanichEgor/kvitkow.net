using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Id комнаты
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime Sended { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Massage { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string UserName { get; set; }
    }
}
