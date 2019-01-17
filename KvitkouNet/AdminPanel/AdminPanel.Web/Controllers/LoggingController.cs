using System.Net.Http;
using System.Threading.Tasks;
using AdminPanel.Logic.Generated.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с логами через панель администратора
	/// </summary>
	[Route("api/admin/logs")]
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
			var res = await _errorLogService.GetErrorLogsWithHttpMessagesAsync(typeName);
			return Ok(res);
		}
	}
}