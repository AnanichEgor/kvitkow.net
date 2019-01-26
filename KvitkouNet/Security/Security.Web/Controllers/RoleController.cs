﻿using System.Collections.Generic;
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

        [HttpGet, Route("roles/{per_page:int}/{page:int}/{mask?}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Role>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetRoles(int per_page, int page, string mask)
        {
            var result = _securityService.GetRoles(per_page, page, mask);
            return Ok(await result);
        }

        [HttpPost, Route("role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRole([FromBody]string roleName)
        {
            var result = _securityService.AddRole(roleName);
            return Ok(await result);
        }

        [HttpDelete, Route("role/{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = _securityService.DeleteRole(id);
            return Ok(await result);
        }

        [HttpPut, Route("role")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditRole([FromBody]int roleId,
            [FromBody]int[] accessRightsIds, [FromBody]int[] deniedRightsIds, [FromBody]int[] functionIds)
        {
            var result = _securityService.EditRole(roleId, accessRightsIds, deniedRightsIds, functionIds);
            return Ok(await result);
        }
    }
}
