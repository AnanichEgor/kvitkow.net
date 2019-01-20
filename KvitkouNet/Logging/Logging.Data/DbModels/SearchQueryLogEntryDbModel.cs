using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    /// <summary>
    /// Модель для логирования поисковых запросов пользователей.
    /// <para>Текст запроса хранится в свойстве Content класса BaseLogEntry.</para>
    /// </summary>
    public class SearchQueryLogEntryDbModel : BaseLogEntry
    {
        /// <summary>
        /// Состояние фильтров при выполнении запросов
        /// </summary>
        public string DashBoardFilterInfo { get; set; }
    }
}
