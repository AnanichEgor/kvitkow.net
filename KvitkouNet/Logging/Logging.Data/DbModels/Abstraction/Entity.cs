using System;

namespace Logging.Data.DbModels.Abstraction
{
    /// <summary>
    /// Базовый класс для всех моделей БД
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Entity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Modified { get; set; }
    }
}
