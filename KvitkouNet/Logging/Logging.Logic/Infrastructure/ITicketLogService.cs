using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами о действиях с билетами
    /// </summary>
    public interface ITicketLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по действиям с билетами
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<TicketActionLogEntry>> GetTicketActionLogsAsync(TicketLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию о действии с билетом
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddTicketActionLogAsync(TicketActionLogEntry entry);
    }
}