using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;

namespace Logging.Logic.Infrastructure
{
    /// <summary>
    /// Интерфейс сервиса для работы с логами о переводах денег
    /// </summary>
    public interface IPaymentLogService : IDisposable
    {
        /// <summary>
        /// Получение логов по платежным операциям
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<PaymentLogEntry>> GetPaymentLogsAsync(PaymentLogsFilter filter);

        /// <summary>
        /// Записывает в лог информацию о проведенном платеже
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
        Task AddPaymentLogAsync(PaymentLogEntry entry);
    }
}