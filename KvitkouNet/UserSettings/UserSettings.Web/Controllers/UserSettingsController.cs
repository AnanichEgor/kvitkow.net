using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using UserSettings.Data.Context;
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

		// TODO перенести в валидацию
		/// <summary>
		/// Валидация данных пользователя. Некоторые поля должны быть обязательно заполнены 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private IEnumerable<string> ValidateUserInfo(Profile model)
		{
			List<String> result = new List<string>();
			if (string.IsNullOrEmpty(model.FirstName))
			{
				result.Add("First name cannot be null or empty");
			}
			if (string.IsNullOrEmpty(model.LastName))
			{
				result.Add("Last name cannot be null or empty");
			}
			return result;
		}

		/// <summary>
		/// Запрос на изменение пароля
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("password")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangePassword([FromBody]PasswordDto model)
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
		public async Task<IActionResult> ChangeEmail([FromBody]string email)
		{
			var result = await _service.UpdateEmail(email);

			return (IActionResult)result;
		}

		//TODO Перенести в валидацию
		/// <summary>
		/// Валидация email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		private bool ValidateEmail(string email)
		{
			string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
			Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
			return isMatch.Success;
		}
	}
}