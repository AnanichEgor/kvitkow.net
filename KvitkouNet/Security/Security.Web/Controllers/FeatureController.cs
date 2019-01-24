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

        [HttpGet, Route("features")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Feature>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetFeatures()
        {
            var result = _securityService.GetFeatures(50, 1);
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
        public async Task<IActionResult> DeleteFeature(int featureId)
        {
            var result = _securityService.DeleteFeature(featureId);
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
