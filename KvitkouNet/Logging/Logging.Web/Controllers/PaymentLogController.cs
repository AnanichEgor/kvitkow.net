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
    [Route("api/logs/payments")]
    public class PaymentLogController : Controller
    {
        private readonly ILoggingService _loggingService;

        public PaymentLogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Получает логи платежных операций
        /// </summary>
        /// <param name="filter">Фильтр логов по платежным операциям</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<PaymentLogEntry>), Description = "Payment logs")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
        public async Task<IActionResult> GetPaymentLogs([FromQuery] PaymentLogsFilter filter)
        {
            if (string.IsNullOrWhiteSpace(filter.UserName))
            {
                return BadRequest($"Invalid filter! {nameof(PaymentLogsFilter.UserName)} is empty or whitespace!");
            }

            var result = await _loggingService.GetPaymentLogsAsync(filter);
            return Ok(result);
        }
    }
}
