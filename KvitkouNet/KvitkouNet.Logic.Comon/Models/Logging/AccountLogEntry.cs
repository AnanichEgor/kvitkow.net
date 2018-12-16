using System;
using KvitkouNet.Logic.Common.Enums;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Запись в лог, описывающая действие с аккаунтом пользователя
    /// </summary>
    public class AccountLogEntry
    {
        public long Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; } 

        /// <summary>
        /// Тип действия
        /// </summary>
        public AccountActionType Type { get; set; }

        /// <summary>
        /// Описание пользовательского устройства
        /// </summary>
        public string DeviceDescription { get; set; }

        /// <summary>
        /// Допольнительные сведения
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата действия
        /// </summary>
        public DateTime Created { get; set; }
    }
}
