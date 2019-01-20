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
    [Route("api/logs/deals")]
    public class TicketDealLogController : Controller
    {
        private readonly IDealLogService _loggingService;

        public TicketDealLogController(IDealLogService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Получает логи сделок по билетам
        /// </summary>
        /// <param name="filter">Фильтр логов по билетам</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<TicketDealLogEntry>), Description = "Ticket deal logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetTicketDealLogs([FromQuery] TicketLogsFilter filter)
        {
            // имитируем некоторую валидацию
            if (string.IsNullOrWhiteSpace(filter.TicketName))
            {
                return BadRequest($"Invalid filter! {nameof(TicketLogsFilter.TicketName)} is empty or whitespace!");
            }

            var result = await _loggingService.GetLogsAsync(filter);
            return Ok(result);
        }
    }
}
