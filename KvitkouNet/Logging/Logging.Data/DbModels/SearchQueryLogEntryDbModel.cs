using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель для логирования поисковых запросов пользователей.
    /// <para>Текст запроса хранится в свойстве Content класса BaseLogEntry.</para>
    /// </summary>
    public class SearchQueryLogEntryDbModel : Entity<string>
    {
        /// <summary>
        /// Состояние фильтров при выполнении запросов
        /// </summary>
        public string DashBoardFilterInfo { get; set; }

        /// <summary>
        /// Дополнительное содержимое записи
        /// </summary>
        public string Content { get; set; }
    }
}
