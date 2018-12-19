using KvitkouNet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Controllers
{
	[Route("api/{id}/usersettings")]
	public class UserSettingsController : Controller
	{
		[HttpPut, Route("changename/first")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeFirstName([FromBody]ChangeNameModel model)
		{
			Task<bool> result = Task.FromResult(
				string.IsNullOrEmpty(model.NewName));

			return await result ? BadRequest("Is null or empty name") : (IActionResult)NoContent();
		}

		[HttpPut, Route("changename/middle")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeMiddleName([FromBody]ChangeNameModel model)
		{
			Task<bool> result = Task.FromResult(
				string.IsNullOrEmpty(model.NewName));

			return await result ? BadRequest("Is null or empty name") : (IActionResult)NoContent();
		}

		[HttpPut, Route("changename/middle")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
		public async Task<IActionResult> ChangeLastName([FromBody]ChangeNameModel model)
		{
			Task<bool> result = Task.FromResult(
				string.IsNullOrEmpty(model.NewName));

			return await result ? BadRequest("Is null or empty name") : (IActionResult)NoContent();
		}
	}
}
