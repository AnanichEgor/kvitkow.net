using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами о сделках с билетами
    /// </summary>
    public interface IDealLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по сделкам с билетами
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<TicketDealLogEntry>> GetTicketDealLogsAsync(TicketLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию о сделке по билету
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddTicketDealLogAsync(TicketDealLogEntry entry);
    }
}