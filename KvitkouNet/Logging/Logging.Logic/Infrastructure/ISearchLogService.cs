using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами поисковых запросов
    /// </summary>
    public interface ISearchLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по поисковым запросам
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryLogEntry>> GetSearchQueryLogsAsync(SearchQueryLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию о поисковом запросе пользователя
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddSearchQueryLogAsync(SearchQueryLogEntry entry);
    }
}