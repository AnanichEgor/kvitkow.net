using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Security;
using KvitkouNet.Logic.Common.Services.Security;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/security")]
    public class SecurityController : Controller
    {
        private ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessRight>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetRights()
        {
            var result = _securityService.GetRights();
            return Ok(await result);
        }

        [HttpPost, Route("add/right")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRight([FromBody]AccessRight right)
        {
            var result = _securityService.AddRight(right);
            return Ok(await result);
        }

        [HttpPost, Route("delete/right")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRight([FromBody]int rightId)
        {
            var result = _securityService.DeleteRight(rightId);
            return Ok(await result);
        }

        [HttpGet, Route("functions")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessFunction>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFunctions()
        {
            var result = _securityService.GetFunctions();
            return Ok(await result);
        }

        [HttpPost, Route("add/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFunction([FromBody]AccessFunction function)
        {
            var result = _securityService.AddFunction(function);
            return Ok(await result);
        }

        [HttpPost, Route("delete/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFunction([FromBody]int functionId)
        {
            var result = _securityService.DeleteFunction(functionId);
            return Ok(await result);
        }

        [HttpPost, Route("edit/function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditFunction([FromBody]AccessFunction function)
        {
            var result = _securityService.EditFunction(function);
            return Ok(await result);
        }

        [HttpGet, Route("features")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Feature>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFeatures()
        {
            var result = _securityService.GetFeatures();
            return Ok(await result);
        }

        [HttpPost, Route("add/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFeature([FromBody]Feature feature)
        {
            var result = _securityService.AddFeature(feature);
            return Ok(await result);
        }

        [HttpPost, Route("delete/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFeature([FromBody]int featureId)
        {
            var result = _securityService.DeleteFeature(featureId);
            return Ok(await result);
        }

        [HttpPost, Route("edit/feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditFeature([FromBody]Feature feature)
        {
            var result = _securityService.EditFeature(feature);
            return Ok(await result);
        }

        [HttpGet, Route("roles")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Role>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetRoles()
        {
            var result = _securityService.GetRoles();
            return Ok(await result);
        }
        
        [HttpPost, Route("add/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRole([FromBody]Role role)
        {
            var result = _securityService.AddRole(role);
            return Ok(await result);
        }

        [HttpPost, Route("delete/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRole([FromBody]int roleId)
        {
            var result = _securityService.DeleteRole(roleId);
            return Ok(await result);
        }

        [HttpPost, Route("edit/role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditRole([FromBody]Role role)
        {
            var result = _securityService.EditRole(role);
            return Ok(await result);
        }

        [HttpPost, Route("fined/user/rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserRights), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "Nothing was found on this request")]
        public async Task<IActionResult> GetUserRights([FromBody]string userId)
        {
            var result = _securityService.GetUserRights(userId);
            return Ok(await result);
        }

        [HttpPost, Route("edit/user/rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditUserRights([FromBody]UserRights userRights)
        {
            var result = _securityService.EditUserRights(userRights);
            return Ok(await result);
        }
    }
}