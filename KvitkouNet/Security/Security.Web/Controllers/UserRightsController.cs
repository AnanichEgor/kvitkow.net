using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Security.Logic.Models;
using Security.Logic.Models.Requests;
using Security.Logic.Services;

namespace Security.Web.Controllers
{
    [Route("api/security")]
    public class UserRightsController : Controller
    {
        private IUserRightsService _securityService;

        public UserRightsController(IUserRightsService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("rights/user/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserRights), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "Nothing was found on this request")]
        public async Task<IActionResult> GetUserRights(string userId)
        {
            var result = _securityService.GetUserRights(userId);
            return Ok(await result);
        }

        [HttpPut, Route("rights/user")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditUserRights([FromBody]string userRightsId, 
            [FromBody]int[] roleIds, [FromBody]int[] functionIds,
            [FromBody]int[] accessedRightsIds, [FromBody]int[] deniedRightsIds)
        {
            var result = _securityService.EditUserRights(userRightsId, roleIds, functionIds, accessedRightsIds, deniedRightsIds);
            return Ok(await result);
        }

        [HttpPut, Route("rights/check")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> CheckUserRights([FromBody]CheckAccessRequest accessRequest)
        {
            var result = _securityService.CheckAccess(accessRequest);
            return Ok(await result);
        }
    }
}
