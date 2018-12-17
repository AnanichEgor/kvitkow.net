using KvitkouNet.Logic.Common.Enums;
using KvitkouNet.Logic.Common.Models.Logging.Abstraction;

namespace KvitkouNet.Logic.Common.Models.Logging
{
    /// <summary>
    /// Запись в лог, описывающая действие с аккаунтом пользователя
    /// </summary>
    public class AccountLogEntry : BaseLogEntry<long>
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User.User User { get; set; } 

        /// <summary>
        /// Тип действия
        /// </summary>
        public AccountActionType Type { get; set; }

        /// <summary>
        /// Описание пользовательского устройства
        /// </summary>
        public string DeviceDescription { get; set; }
    }
}
