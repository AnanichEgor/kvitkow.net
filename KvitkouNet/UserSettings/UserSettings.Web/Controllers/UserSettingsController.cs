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
		[HttpPut, Route("userinfo")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdateProfile([FromBody]Profile model)
		{
			var result = await _service.UpdateProfile(model);

			return (IActionResult)result;
		}

		/// <summary>
		/// Запрос на изменение пароля
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("password")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdatePassword([FromBody]PasswordDto model)
		{
			var result = await _service.UpdatePassword(model.OldPassword, model.NewPassword, model.ConfirmPassword);

			return (IActionResult)result;
		}

		/// <summary>
		/// Запрос на изменение email
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("email")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> UpdateEmail([FromBody]EmailDto model)
		{
			var result = await _service.UpdateEmail(model.Id, model.Email);

			return result == true ? (IActionResult)Ok(result) : BadRequest(); 
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

		[HttpGet, Route("{id}")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Settings>), Description = "All Ok")]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> Get([FromRoute] string id)
		{
			int temp;
			int.TryParse(id, out temp);
			var resulttemp = await _service.ShowAll();
			var result = await _service.Get(temp);
			return Ok(result);
		}
	}
}