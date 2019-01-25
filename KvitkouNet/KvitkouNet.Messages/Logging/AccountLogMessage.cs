using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.Logging
{
    /// <summary>
    /// Модель сообщения о действии с аккаунтом пользователя
    /// </summary>
    public class AccountLogMessage
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Описание пользовательского устройства
        /// </summary>
        public string DeviceDescription { get; set; }

        /// <summary>
        /// Дата действия
        /// </summary>
        public DateTime Date { get; set; }
    }
}
