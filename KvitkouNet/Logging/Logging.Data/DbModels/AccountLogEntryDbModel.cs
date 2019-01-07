using Logging.Data.DbModels.Abstraction;
using Logging.Logic.Common.Enums;

namespace Logging.Data.DbModels
{
    public class AccountLogEntryDbModel : Entity<long>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Тип действия
        /// </summary>
        public AccountActionType Type { get; set; }

        /// <summary>
        /// Описание пользовательского устройства
        /// </summary>
        public string DeviceDescription { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
