using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Logging.Web.Controllers
{
    [Route("api/logs/tickets")]
    public class TicketActionLogController : Controller
    {
        private readonly ILoggingService _loggingService;

        public TicketActionLogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Получает логи действий с билетами
        /// </summary>
        /// <param name="filter">Фильтр логов по билетам</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<TicketActionLogEntry>), Description =
            "Ticket action logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetTicketActionLogs([FromQuery] TicketLogsFilter filter)
        {
            // имитируем некоторую валидацию
            if (string.IsNullOrWhiteSpace(filter.TicketName))
            {
                return BadRequest($"Invalid filter! {nameof(TicketLogsFilter.TicketName)} is empty or whitespace!");
            }

            var result = await _loggingService.GetTicketActionLogsAsync(filter);
            return Ok(result);
        }
    }
}
