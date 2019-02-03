using System;
using System.Net.Http;
using System.Threading.Tasks;
using AdminPanel.Logic.Generated.Logging;
using AdminPanel.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;

namespace AdminPanel.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с логами через панель администратора
	/// </summary>
	[Route("api/admin/logs")]
	[ServiceFilter(typeof(GlobalExceptionFilter))]
	public class LoggingController : Controller
	{
		private readonly IErrorLog _errorLogService;
		private readonly IAccountLog _accountLogService;

		public LoggingController(IErrorLog errorLogService, IAccountLog accountLogService)
		{
			_errorLogService = errorLogService;
			_accountLogService = accountLogService;
		}

		/// <summary>
		/// Возвращает список залогированных ошибок
		/// </summary>
		/// <returns></returns>
		[HttpGet("errors")]
		public async Task<IActionResult> GetErrorLogs([FromQuery] string serviceName,
			string exceptionTypeName,
			string message,
			DateTime? dateFrom,
			DateTime? dateTo)
		{
			try
			{
				return Ok(await _errorLogService.GetErrorLogsAsync(serviceName: serviceName, exceptionTypeName:exceptionTypeName, message:message, dateFrom:dateFrom, dateTo:dateTo));
			}
			catch (SerializationException e)
			{
				return BadRequest($"{e.Message} : {e.Content}");
			}
		}

		/// <summary>
		/// Возвращает список логов по действиям с аккаунтом
		/// </summary>
		/// <returns></returns>
		[HttpGet("accounts")]
		public async Task<IActionResult> GetAccountLogs([FromQuery] string userId,
			string userName,
			string email,
			int type,
			DateTime? dateFrom,
			DateTime? dateTo)
		{
			try
			{
				return Ok(await _accountLogService.GetAccountLogsAsync(userId:userId, userName:userName, email:email, type:type, dateFrom:dateFrom, dateTo:dateTo));
			}
			catch (SerializationException e)
			{
				return BadRequest($"{e.Message} : {e.Content}");
			}
		}
	}
}