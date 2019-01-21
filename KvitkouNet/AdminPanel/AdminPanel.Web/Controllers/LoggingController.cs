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
		/// <summary>
		/// Возвращает список залогированных ошибок
		/// </summary>
		/// <returns></returns>
		[HttpGet("errors")]
		public async Task<IActionResult> GetErrors([FromQuery] string typeName)
		{
			var errorLogService = new ErrorLog(new MyTitle(new HttpClient(), true));
			var res = await errorLogService.GetErrorLogsWithHttpMessagesAsync(typeName);
			return Ok(res);
		}
	}
}