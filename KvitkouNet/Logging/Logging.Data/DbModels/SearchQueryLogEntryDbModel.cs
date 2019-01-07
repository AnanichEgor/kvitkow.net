using Logging.Data.DbModels.Abstraction;

namespace Logging.Data.DbModels
{
    public class SearchQueryLogEntryDbModel : Entity<long>
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
