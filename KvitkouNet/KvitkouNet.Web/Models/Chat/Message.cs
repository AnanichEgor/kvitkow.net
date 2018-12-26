using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.Chat
{
    public class Message
    {
        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime Sended { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string UserName { get; set; }
    }
}
