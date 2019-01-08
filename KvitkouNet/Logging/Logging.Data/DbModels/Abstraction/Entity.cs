using System;

namespace Logging.Data.DbModels.Abstraction
{
    /// <summary>
    /// Базовый класс для всех моделей БД
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Entity<TKey>
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата изменения записи
        /// </summary>
        public DateTime? Modified { get; set; }
    }
}
