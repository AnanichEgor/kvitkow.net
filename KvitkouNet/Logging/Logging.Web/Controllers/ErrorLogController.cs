using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using FluentValidation;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Logging.Logic.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Logging.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с логами об ошибках
	/// </summary>
	[Route("api/logs/errors")]
	public class ErrorLogController : Controller
	{
		private readonly IErrorLogService _loggingService;
	    private bool _disposed;
        private readonly IValidator<ErrorLogsFilter> _errorLogsFilterValidator;

		public ErrorLogController(IErrorLogService loggingService, IValidator<ErrorLogsFilter> errorLogsFilterValidator)
		{
			_loggingService = loggingService;
			_errorLogsFilterValidator = errorLogsFilterValidator;
			_bus = bus;
		}

		/// <summary>
		/// Получает логи ошибок сервера по фильтру
		/// </summary>
		/// <param name="filter">Фильтр логов ошибок сервера</param>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<InternalErrorLogEntry>), Description = "Error logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetErrorLogs([FromQuery] ErrorLogsFilter filter)
		{
			// имитируем некоторую валидацию
			if (!_errorLogsFilterValidator.Validate(filter).IsValid)
			{
				return BadRequest(
					$"Invalid filter! {nameof(ErrorLogsFilter.ExceptionTypeName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetLogsAsync(filter);
			return Ok(result);
		}

	    protected override void Dispose(bool disposing)
	    {
	        if (_disposed)
	        {
	            return;
	        }

	        if (disposing)
	        {
	            _loggingService?.Dispose();
	        }

	        _disposed = true;

	        base.Dispose(disposing);
	    }
    }
}
