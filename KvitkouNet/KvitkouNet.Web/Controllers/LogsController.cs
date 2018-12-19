using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;
using KvitkouNet.Logic.Common.Models.Logging.Abstraction;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за получение логов
    /// </summary>
    [Route("api/logs")]
    public class LogsController : Controller
    {
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

            await Task.Delay(1000);

            return Ok(new List<AccountLogEntry>());
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
                return BadRequest($"Invalid filter! {nameof(ErrorLogsFilterDto.ExceptionTypeName)} is empty or whitespace!");
            }

            await Task.Delay(1000);

            return Ok(new List<InternalErrorLogEntry>());
        }

        /// <summary>
        /// Получает логи действий с билетами
        /// </summary>
        /// <param name="filter">Фильтр логов по билетам</param>
        /// <returns></returns>
        [HttpGet]
        [Route("tickets/actions")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<TicketActionLogEntry>), Description = "Ticket action logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetTicketActionLogs([FromQuery] TicketLogsFilterDto filter)
        {
            // имитируем некоторую валидацию
            if (string.IsNullOrWhiteSpace(filter.TicketName))
            {
                return BadRequest($"Invalid filter! {nameof(TicketLogsFilterDto.TicketName)} is empty or whitespace!");
            }

            await Task.Delay(1000);

            return Ok(new List<TicketActionLogEntry>());
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

		    await Task.Delay(1000);

		    return Ok(new List<TicketDealLogEntry>());
	    }

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

		    await Task.Delay(100);

		    return Ok(new List<PaymentLogEntry>());
	    }

	    [HttpGet]
	    [Route("queries")]
	    [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<SearchQueryLogEntry>), Description = "Search query logs")]
	    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetSearchQueryLogs([FromQuery] SearchQueryLogsFilterDto filter)
	    {
		    if (string.IsNullOrWhiteSpace(filter.UserName))
		    {
			    return BadRequest($"Invalid filter! {nameof(SearchQueryLogsFilterDto.UserName)} is empty or whitespace!");
		    }

		    await Task.Delay(100);

		    return Ok(new List<SearchQueryLogEntry>());
		}
	}
}
