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
    public class FunctionsController : Controller
    {
        private IFunctionService _securityService;

        public FunctionsController(IFunctionService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("functions")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessFunction>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFunctions()
        {
            var result = _securityService.GetFunctions(50, 1);
            return Ok(await result);
        }

        [HttpPost, Route("function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFunction([FromBody]AccessFunction function)
        {
            var result = _securityService.AddFunction(function);
            return Ok(await result);
        }

        [HttpDelete, Route("function/{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFunction(int functionId)
        {
            var result = _securityService.DeleteFunction(functionId);
            return Ok(await result);
        }

        [HttpPut, Route("function")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditFunction([FromBody]AccessFunction function)
        {
            var result = _securityService.EditFunction(function);
            return Ok(await result);
        }
    }
}
