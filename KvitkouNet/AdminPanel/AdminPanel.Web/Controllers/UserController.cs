using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с пользователями через панель администратора
	/// </summary>
	[Route("api/admin/users")]
	public class UserController : Controller
	{
		public UserController()
		{
			
		}

		/// <summary>
		/// Получает пользователей для просмотра с помощью панели администратора
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			return Ok();
		}

		[HttpPut]
		[Route("ban/{id}")]
		public async Task<IActionResult> BanUser(int id)
		{
			return NoContent();
		}

		[HttpPut]
		[Route("unban/{id}")]
		public async Task<IActionResult> UnbanUser(int id)
		{
			return NoContent();
		}
	}
}