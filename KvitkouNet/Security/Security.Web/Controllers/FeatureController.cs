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
    public class FeatureController : Controller
    {
        private IFeatureService _securityService;

        public FeatureController(IFeatureService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("features/{per_page:int}/{page:int}/{mask?}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Feature>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFeatures(int per_page, int page, string mask)
        {
            var result = _securityService.GetFeatures(per_page, page, mask);
            return Ok(await result);
        }

        [HttpPost, Route("feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> AddFeature([FromBody]Feature feature)
        {
            var result = _securityService.AddFeature(feature);
            return Ok(await result);
        }

        [HttpDelete, Route("feature/{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var result = _securityService.DeleteFeature(id);
            return Ok(await result);
        }

        [HttpPut, Route("feature")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> EditFeature([FromBody]Feature feature)
        {
            var result = _securityService.EditFeature(feature);
            return Ok(await result);
        }
    }
}
