using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Запись в лог, описывающая действие с аккаунтом пользователя
    /// </summary>
    public class AccountLogEntryDbModel : BaseLogEntryDbModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Тип действия
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Описание пользовательского устройства
        /// </summary>
        public string DeviceDescription { get; set; }
    }
}
