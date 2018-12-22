using System;
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
        [HttpGet, Route("all/rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessRight>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllRights()
        {
            var result = Task.FromResult(new List<AccessRight> {new AccessRight{Name = "FakeRight" } });
            return Ok(await result);
        }

        [HttpPost, Route("add/right")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRight([FromBody]AccessRight right)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("delete/right")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRight([FromBody]Guid rightId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpGet, Route("all/functions")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessFunction>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllFunctions()
        {
            var result = Task.FromResult(new List<AccessFunction> {new AccessFunction { Name = "FakeFunction" } });
            return Ok(await result);
        }

        [HttpPost, Route("add/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFunction([FromBody]AccessFunction function)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("delete/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFunction([FromBody]Guid functionId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("update/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> UpdateFunction([FromBody]AccessFunction function)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpGet, Route("all/features")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Feature>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllFeatures()
        {
            var result = Task.FromResult(new List<Feature> {new Feature { Name = "FakeFeature" } });
            return Ok(await result);
        }

        [HttpPost, Route("add/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFeature([FromBody]Feature feature)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("delete/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFeature([FromBody]Guid featureId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("update/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> UpdateFeature([FromBody]Feature feature)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpGet, Route("all/roles")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Role>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = Task.FromResult(new List<Role> {new Role { Name = "FakeRole" } });
            return Ok(await result);
        }
        
        [HttpPost, Route("add/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRole([FromBody]Role role)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("delete/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRole([FromBody]Guid roleId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("update/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> UpdateRole([FromBody]Role role)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        [HttpPost, Route("fined/user/rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserRights), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "Nothing was found on this request")]
        public async Task<IActionResult> FinedUserRights([FromBody]Guid userId)
        {
            var result = Task.FromResult(new UserRights { UserLogin = "empty"});
            return Ok(await result);
        }

        [HttpPost, Route("update/user/rights")]
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