﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Logging.Logic.Dtos;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Logging.Web.Controllers
{
	/// <summary>
	/// Контроллер, отвечающий за получение логов об ошибках
	/// </summary>
	[Route("api/logs/errors")]
	public class ErrorLogsController : Controller
	{
		private readonly ILoggingService _loggingService;
		private readonly IValidator<ErrorLogsFilterDto> _errorLogsFilterValidator;

		public ErrorLogsController(ILoggingService loggingService, IValidator<ErrorLogsFilterDto> errorLogsFilterValidator)
		{
			_loggingService = loggingService;
			_errorLogsFilterValidator = errorLogsFilterValidator;
		}

		/// <summary>
		/// Получает логи ошибок сервера
		/// </summary>
		/// <param name="filter">Фильтр логов ошибок сервера</param>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<InternalErrorLogEntry>), Description = "Error logs")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid filter")]
		public async Task<IActionResult> GetErrorLogs([FromQuery] ErrorLogsFilterDto filter)
		{
			// имитируем некоторую валидацию
			if (!_errorLogsFilterValidator.Validate(filter).IsValid)
			{
				return BadRequest(
					$"Invalid filter! {nameof(ErrorLogsFilterDto.ExceptionTypeName)} is empty or whitespace!");
			}

			var result = await _loggingService.GetErrorLogsAsync(filter);
			return Ok(result);
		}
	}
}
