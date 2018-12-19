using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Security;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/security")]
    public class SecurityController : Controller
    {
        [HttpGet, Route("allRights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessRight>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllRights()
        {
            var result = Task.FromResult(new List<AccessRight> {new AccessRight{Name = "FakeRight" } });
            return Ok(await result);
        }

        [HttpGet, Route("allFunctions")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessFunction>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllFunctions()
        {
            var result = Task.FromResult(new List<AccessFunction> {new AccessFunction { Name = "FakeFunction" } });
            return Ok(await result);
        }

        [HttpGet, Route("allRoles")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Role>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = Task.FromResult(new List<Role> {new Role { Name = "FakeRole" } });
            return Ok(await result);
        }

        [HttpPost, Route("finedUserRights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserRights), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "Nothing was found on this request")]
        public async Task<IActionResult> FinedUserRights([FromBody]string userId)
        {
            var result = Task.FromResult(new UserRights { UserLogin = "empty"});
            return Ok(await result);
        }

        [HttpPost, Route("updateUserRights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> UpdateUserRights([FromBody]UserRights userRights)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }
    }
}