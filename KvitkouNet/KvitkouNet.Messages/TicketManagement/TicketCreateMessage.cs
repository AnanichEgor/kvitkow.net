using System;

namespace KvitkouNet.Messages.TicketManagement
{
    public class TicketCreateMessage
    {
        /// <summary>
        ///     Id пользователя сделавшего билет
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Id созданного билета
        /// </summary>
        public string TicketId { get; set; }

        /// <summary>
        ///     Дата создания билета
        /// </summary>
        public DateTime Create { get; set; }
    }
}