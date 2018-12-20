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
	[Route("api/{id}/usersettings")]
	public class UserSettingsController : Controller
	{
		[HttpPut, Route("changepforile")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeUserProfile([FromBody]UserProfileModel model)
		{
			IEnumerable<string> result = await Task.Run(() => ValidateProfile(model));
		
			if(result.Count() == 0)
			{
				return (IActionResult)NoContent();
			}
			else
			{
				return BadRequest(result);
			}
		}

		private IEnumerable<string> ValidateProfile(UserProfileModel model)
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

		[HttpPut, Route("changepassword")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangePassword([FromBody]UserAccountModel model)
		{
			Task<bool> result = Task.FromResult(
				string.Equals(model.NewPassword, model.ConfirmPassword));

			return await result ? (IActionResult)NoContent() : BadRequest("New and confirm password do not match");
		}

		[HttpPut, Route("changeemail")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeEmail([FromBody]UserAccountModel model)
		{
			Task<bool> result = Task.FromResult(
				ValidateEmail(model.Email)
				);

			return await result ? (IActionResult)NoContent() : BadRequest("New and confirm password do not match");
		}

		private bool ValidateEmail(string email)
		{
			string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
			Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
			return isMatch.Success;
		}
	}
}
