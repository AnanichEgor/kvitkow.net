using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Logging.Logic.Dtos;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Logging.Web.Controllers
{
    [Route("api/logs/queries")]
    public class QueryLogController : Controller
    {
        private readonly ILoggingService _loggingService;

        public QueryLogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Получает логи поисковых запросов пользователей
        /// </summary>
        /// <param name="filter">Фильтр логов по поисковым запросам</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
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
