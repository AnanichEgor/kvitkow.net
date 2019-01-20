using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами об ошибках
    /// </summary>
    public interface IErrorLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по ошибкам
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<InternalErrorLogEntry>> GetErrorLogsAsync(ErrorLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию об ошибке в работе сервиса
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddErrorLogAsync(InternalErrorLogEntry entry);
    }
}