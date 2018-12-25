using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;

namespace KvitkouNet.Logic.Common.Services.Logging
{
	/// <summary>
	/// Интерфейс сервиса для работы с логами
	/// </summary>
	public interface ILoggingService
	{
		/// <summary>
		/// Получение логов по действиям с аккаунтами
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<AccountLogEntry>> GetAccountLogs(AccountLogsFilterDto filter);

		/// <summary>
		/// Получение логов по ошибкам
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<InternalErrorLogEntry>> GetErrorLogs(ErrorLogsFilterDto filter);

		/// <summary>
		/// Получение логов по действиям с билетами
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<TicketActionLogEntry>> GetTicketActionLogs(TicketLogsFilterDto filter);

		/// <summary>
		/// Получение логов по сделкам с билетами
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<TicketDealLogEntry>> GetTicketDealLogs(TicketLogsFilterDto filter);

		/// <summary>
		/// Получение логов по платежным операциям
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<PaymentLogEntry>> GetPaymentLogs(PaymentLogsFilterDto filter);

		/// <summary>
		/// Получение логов по поисковым запросам
		/// </summary>
		/// <param name="filter">Фильтр для получения логов</param>
		/// <returns></returns>
		Task<IEnumerable<SearchQueryLogEntry>> GetSearchQueryLogs(SearchQueryLogsFilterDto filter);
	}
}
