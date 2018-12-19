using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Dtos.Logging;
using KvitkouNet.Logic.Common.Models.Logging;
using KvitkouNet.Web.Models;
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
        /// <param name="filter">Фильтр</param>
        /// <returns></returns>
        [HttpGet]
        [Route("accounts")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<AccountLogEntry>), Description = "Account logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetAccountLogs([FromQuery] AccountLogsFilterDto filter)
        {
            await Task.Delay(1000);

            if (string.IsNullOrWhiteSpace(filter.UserName))
            {
                return BadRequest($"Invalid filter! Property {nameof(AccountLogsFilterDto.UserName)} is empty or whitespace!");
            }

            return Ok(new List<AccountLogEntry>());
        }

        [HttpGet]
        [Route("errors")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<InternalErrorLogEntry>), Description = "Error logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetErrorLogs([FromQuery] ErrorLogsFilterDto filter)
        {
            await Task.Delay(1000);

            if (string.IsNullOrWhiteSpace(filter.ExceptionTypeName))
            {
                return BadRequest($"Invalid filter! Property {nameof(ErrorLogsFilterDto.ExceptionTypeName)} is empty or whitespace!");
            }

            return Ok(new List<InternalErrorLogEntry>());
        }
    }
}
