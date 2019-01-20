using System;

namespace Logging.Data.DbModels.Abstraction
{
    /// <summary>
    /// Базовый класс для всех бд-моделей записей лога
    /// </summary>
    public abstract class BaseLogEntryDbModel
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
