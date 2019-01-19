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
	[GlobalExceptionFilter]
	public class LoggingController : Controller
	{
		private readonly IErrorLog _errorLogService;

		public LoggingController(IErrorLog errorLogService)
		{
			_errorLogService = errorLogService;
		}

		/// <summary>
		/// Возвращает список залогированных ошибок
		/// </summary>
		/// <returns></returns>
		[HttpGet("errors")]
		public async Task<IActionResult> GetErrors([FromQuery] string typeName)
		{
			object res;
			try
			{
				res = await _errorLogService.GetErrorLogsAsync(typeName);
			}
			//catch (SerializationException e)
			//{
			//	return BadRequest($"{e.Message} : {e.Content}");
			//}
			catch (ArgumentException e)
			{
				res = null;
			}
			
			return Ok(res);
		}
	}
}