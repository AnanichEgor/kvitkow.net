using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.Chat
{
    public class MessageModel
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime SendedTime { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string UserId { get; set; }
    }
}
