using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Logging.Logic.Dtos;
using Logging.Logic.Models;
using Logging.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Logging.Web.Controllers
{
	/// <summary>
	/// Контроллер, отвечающий за получение логов
	/// </summary>
	[Route("api/logs")]
	public class LogsController : Controller
	{
		private readonly ILoggingService _loggingService;

		public LogsController(ILoggingService loggingService)
		{
			_loggingService = loggingService;
		}

		/// <summary>
		/// Получает логи действий с аккаунтами пользователей
		/// </summary>
		/// <param name="filter">Фильтр логов действий с аккаунтами</param>
		/// <returns></returns>
		[HttpGet]
		[Route("accounts")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<AccountLogEntry>), Description = "Account logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetAccountLogs([FromQuery] AccountLogsFilterDto filter)
		{
			// имитируем некоторую валидацию
			if (string.IsNullOrWhiteSpace(filter.UserName))
			{
				return BadRequest($"Invalid filter! {nameof(AccountLogsFilterDto.UserName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetAccountLogsAsync(filter);
			return Ok(result);
		}

		/// <summary>
		/// Получает логи ошибок сервера
		/// </summary>
		/// <param name="filter">Фильтр логов ошибок сервера</param>
		/// <returns></returns>
		[HttpGet]
		[Route("errors")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<InternalErrorLogEntry>), Description = "Error logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetErrorLogs([FromQuery] ErrorLogsFilterDto filter)
		{
			// имитируем некоторую валидацию
			if (string.IsNullOrWhiteSpace(filter.ExceptionTypeName))
			{
				return BadRequest(
					$"Invalid filter! {nameof(ErrorLogsFilterDto.ExceptionTypeName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetErrorLogsAsync(filter);
			return Ok(result);
		}

		/// <summary>
		/// Получает логи действий с билетами
		/// </summary>
		/// <param name="filter">Фильтр логов по билетам</param>
		/// <returns></returns>
		[HttpGet]
		[Route("tickets/actions")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<TicketActionLogEntry>), Description =
			"Ticket action logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetTicketActionLogs([FromQuery] TicketLogsFilterDto filter)
		{
			// имитируем некоторую валидацию
			if (string.IsNullOrWhiteSpace(filter.TicketName))
			{
				return BadRequest($"Invalid filter! {nameof(TicketLogsFilterDto.TicketName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetTicketActionLogsAsync(filter);
			return Ok(result);
		}

		/// <summary>
		/// Получает логи сделок по билетам
		/// </summary>
		/// <param name="filter">Фильтр логов по билетам</param>
		/// <returns></returns>
		[HttpGet]
		[Route("tickets/deals")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<TicketDealLogEntry>), Description = "Ticket deal logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetTicketDealLogs([FromQuery] TicketLogsFilterDto filter)
		{
			// имитируем некоторую валидацию
			if (string.IsNullOrWhiteSpace(filter.TicketName))
			{
				return BadRequest($"Invalid filter! {nameof(TicketLogsFilterDto.TicketName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetTicketDealLogsAsync(filter);
			return Ok(result);
		}

		/// <summary>
		/// Получает логи платежных операций
		/// </summary>
		/// <param name="filter">Фильтр логов по платежным операциям</param>
		/// <returns></returns>
		[HttpGet]
		[Route("payments")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<PaymentLogEntry>), Description = "Payment logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetPaymentLogs([FromQuery] PaymentLogsFilterDto filter)
		{
			if (string.IsNullOrWhiteSpace(filter.UserName))
			{
				return BadRequest($"Invalid filter! {nameof(PaymentLogsFilterDto.UserName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetPaymentLogsAsync(filter);
			return Ok(result);
		}

		/// <summary>
		/// Получает логи поисковых запросов пользователей
		/// </summary>
		/// <param name="filter">Фильтр логов по поисковым запросам</param>
		/// <returns></returns>
		[HttpGet]
		[Route("queries")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<SearchQueryLogEntry>), Description =
			"Search query logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetSearchQueryLogs([FromQuery] SearchQueryLogsFilterDto filter)
		{
			if (string.IsNullOrWhiteSpace(filter.UserName))
			{
				return BadRequest(
					$"Invalid filter! {nameof(SearchQueryLogsFilterDto.UserName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetSearchQueryLogsAsync(filter);
			return Ok(result);
		}
	}
}
