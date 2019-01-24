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
    public class FunctionsController : Controller
    {
        private IFunctionService _securityService;

        public FunctionsController(IFunctionService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("functions{per_page:int}/{page:int}/{mask?}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<AccessFunction>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFunctions(int per_page, int page, string mask)
        {
            var result = _securityService.GetFunctions(per_page, page, mask);
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
        public async Task<IActionResult> DeleteFunction(int id)
        {
            var result = _securityService.DeleteFunction(id);
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
