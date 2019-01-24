using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Security.Logic.Models;
using Security.Logic.Services;

namespace Security.Web.Controllers
{
    [Route("api/security")]
    public class RightsController : Controller
    {
        private IRightsService _securityService;

        public RightsController(IRightsService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("rights")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessRight>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetRights()
        {
            var result = _securityService.GetRights(50, 1);
            return Ok(await result);
        }

        [HttpPost, Route("right")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddRight([FromBody]AccessRight right)
        {
            var result = _securityService.AddRights(new[] {right});
            return Ok(await result);
        }

        [HttpDelete, Route("right/{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteRight(int rightId)
        {
            var result = _securityService.DeleteRight(rightId);
            return Ok(await result);
        }
    }
}
