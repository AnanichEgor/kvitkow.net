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
		public IActionResult Index()
		{
			return Ok();
		}
	}
}