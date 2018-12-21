using KvitkouNet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Controllers
{
	[Route("api/users/settings/{id}")]
	public class UserSettingsController : Controller
	{
		/// <summary>
		/// Запрос на изменение данных профиля пользователя
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("profile")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeUserProfile([FromBody]ProfileDto model)
		{
			IEnumerable<string> result = await Task.FromResult(ValidateProfile(model));
		
			if(result.Count() == 0)
			{
				return (IActionResult)NoContent();
			}
			else
			{
				return BadRequest(result);
			}
		}

		// TODO при необходимости добавить другие проверки
		/// <summary>
		/// Валидация данных пользователя. Некоторые поля должны быть обязательно заполнены 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private IEnumerable<string> ValidateProfile(ProfileDto model)
		{
			List<String> result = new List<string>();
			if(string.IsNullOrEmpty(model.FirstName))
			{
				result.Add("First name cannot be null or empty");
			}
			if(string.IsNullOrEmpty(model.LastName))
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
		public async Task<IActionResult> ChangePassword([FromBody]AccountDto model)
		{
			Task<bool> result = Task.FromResult(
				string.Equals(model.NewPassword, model.ConfirmPassword));

			return await result ? (IActionResult)NoContent() : BadRequest("New and confirm password do not match");
		}

		/// <summary>
		/// Запрос на изменение email
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut, Route("email")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeEmail([FromBody]AccountDto model)
		{
			Task<bool> result = Task.FromResult(
				ValidateEmail(model.Email)
				);

			return await result ? (IActionResult)NoContent() : BadRequest("Incorrect email");
		}

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
