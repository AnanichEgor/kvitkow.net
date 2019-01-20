using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами аккаунтов
    /// </summary>
    public interface IAccountLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по действиям с аккаунтами
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<AccountLogEntry>> GetAccountLogsAsync(AccountLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию о действии с пользовательским аккаунтом
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddAccountLogAsync(AccountLogEntry entry);
    }
}