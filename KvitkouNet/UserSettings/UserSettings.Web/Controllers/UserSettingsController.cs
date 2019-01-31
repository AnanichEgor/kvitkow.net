using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using UserSettings.Logic.Models;
using UserSettings.Logic.Services;
using UserSettings.Web.Models;

namespace UserSettings.Web.Controllers
{
	[Route("api/settings")]
	public class UserSettingsController : Controller
    {
		private IUserSettingsService _service;
		public UserSettingsController(IUserSettingsService service)
		{
			_service = service;
		}

		/// <summary>
		/// Запрос на изменение основных данных пользователя
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/userinfo")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdateProfile([FromBody]ProfileDto model, [FromRoute] string id)
		{
			var result = await _service.UpdateProfile(id, model.FirstName, model.MiddleName, model.LastName);
			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		/// <summary>
		/// Запрос на изменение пароля
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/password")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdatePassword([FromBody]PasswordDto model, [FromRoute] string id)
		{
			var result = await _service.UpdatePassword(id, model.OldPassword, model.NewPassword, model.ConfirmPassword);

			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		/// <summary>
		/// Запрос на изменение email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/email")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdateEmail([FromBody]string email, [FromRoute]string id)
		{

			var result = await _service.UpdateEmail(id, email);
			return result ? (IActionResult)Ok(result) : BadRequest(); 
		}

		/// <summary>
		/// Запрос на изменение email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpGet, Route("{id}/email")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> GetEmail([FromBody]string email, [FromRoute]string id)
		{

			var result = await _service.UpdateEmail(id, email);
			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		/// <summary>
		/// Запрос на изменение уведомлений
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/notifications")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdateNotification([FromBody]Notifications notification, [FromRoute]string id)
		{
			var result = await _service.UpdateNotifications(id, notification);
			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		/// <summary>
		/// Запрос на изменение уведомлений
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/preferences")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdatePreferences([FromBody]PreferncesDto preferences, [FromRoute]string id)
		{
			var result = await _service.UpdatePreferences(id, preferences.Addres, preferences.Region, preferences.Place);
			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		/// <summary>
		/// Запрос на удаление аккаунта
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("{id}/delete")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> DeleteAccount([FromRoute] string id)
		{
			var result = await _service.DeleteAccount(id);
			return result ? (IActionResult)Ok(result) : BadRequest();
		}

		[HttpGet]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Settings>), Description = "All Ok")]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.ShowAll();
			return Ok(result);
		}
	}
}