using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;

namespace KvitkouNet.Logic.Common.Services.Logging
{
	/// <summary>
	/// Интерфейс сервиса для работы с логами
	/// </summary>
	public interface ILoggingService : IDisposable
	{
		/// <summary>
		/// Получение логов по действиям с аккаунтами
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<AccountLogEntry>> GetAccountLogsAsync(AccountLogsFilterDto filter);

        /// <summary>
        /// Записывает в лог информацию о действии с пользовательским аккаунтом
        /// </summary>
        /// <param name="entry">Модель записи</param>
        /// <returns></returns>
	    Task AddAccountLogAsync(AccountLogEntry entry);

        /// <summary>
        /// Получение логов по ошибкам
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<InternalErrorLogEntry>> GetErrorLogsAsync(ErrorLogsFilterDto filter);

	    /// <summary>
	    /// Записывает в лог информацию об ошибке в работе сервиса
	    /// </summary>
	    /// <param name="entry">Модель записи</param>
	    /// <returns></returns>
	    Task AddErrorLogAsync(InternalErrorLogEntry entry);

        /// <summary>
        /// Получение логов по действиям с билетами
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<TicketActionLogEntry>> GetTicketActionLogsAsync(TicketLogsFilterDto filter);

	    /// <summary>
	    /// Записывает в лог информацию о действии с билетом
	    /// </summary>
	    /// <param name="entry">Модель записи</param>
	    /// <returns></returns>
	    Task AddTicketActionLogAsync(TicketActionLogEntry entry);

        /// <summary>
        /// Получение логов по сделкам с билетами
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<TicketDealLogEntry>> GetTicketDealLogsAsync(TicketLogsFilterDto filter);

	    /// <summary>
	    /// Записывает в лог информацию о сделке по билету
	    /// </summary>
	    /// <param name="entry">Модель записи</param>
	    /// <returns></returns>
	    Task AddTicketDealLogAsync(TicketDealLogEntry entry);

        /// <summary>
        /// Получение логов по платежным операциям
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<PaymentLogEntry>> GetPaymentLogsAsync(PaymentLogsFilterDto filter);

	    /// <summary>
	    /// Записывает в лог информацию о проведенном платеже
	    /// </summary>
	    /// <param name="entry">Модель записи</param>
	    /// <returns></returns>
	    Task AddPaymentLogAsync(PaymentLogEntry entry);

        /// <summary>
        /// Получение логов по поисковым запросам
        /// </summary>
        /// <param name="filter">Фильтр для получения логов</param>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryLogEntry>> GetSearchQueryLogsAsync(SearchQueryLogsFilterDto filter);

	    /// <summary>
	    /// Записывает в лог информацию о поисковом запросе пользователя
	    /// </summary>
	    /// <param name="entry">Модель записи</param>
	    /// <returns></returns>
	    Task AddSearchQueryLogAsync(SearchQueryLogEntry entry);
    }
}
