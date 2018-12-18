using System;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        [HttpPost, Route("register")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Register([FromBody]UserRegisterModel model)
        {
            Task<bool> result = Task.FromResult(
                model.Password.Equals(model.ConfirmPassword,
                    StringComparison.OrdinalIgnoreCase));
            
            return await result?
                (IActionResult) NoContent() : BadRequest("Password error");
        }
    }
}