using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Security.Logic.Models;
using Security.Logic.Services;

namespace Security.Web.Controllers
{
    [Route("api/security")]
    public class RoleController : Controller
    {
        private IRoleService _securityService;

        public RoleController(IRoleService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("roles")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Role>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetRoles()
        {
            var result = _securityService.GetRoles(50, 1);
            return Ok(await result);
        }

        [HttpPost, Route("role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRole([FromBody]Role role)
        {
            var result = _securityService.AddRole(role);
            return Ok(await result);
        }

        [HttpDelete, Route("role/{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var result = _securityService.DeleteRole(roleId);
            return Ok(await result);
        }

        [HttpPut, Route("role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditRole([FromBody]Role role)
        {
            var result = _securityService.EditRole(role);
            return Ok(await result);
        }
    }
}
