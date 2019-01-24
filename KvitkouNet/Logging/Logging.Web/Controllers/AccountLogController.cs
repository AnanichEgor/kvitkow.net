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
    [Route("api/logs/accounts")]
    public class AccountLogController : Controller
    {
        private readonly ILoggingService _loggingService;

        public AccountLogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Получает логи действий с аккаунтами пользователей
        /// </summary>
        /// <param name="filter">Фильтр логов действий с аккаунтами</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
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
    }
}
