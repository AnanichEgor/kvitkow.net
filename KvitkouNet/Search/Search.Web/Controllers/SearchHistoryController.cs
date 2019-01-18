using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Search.Logic.Services;

namespace Search.Web.Controllers
{
    /// <summary>
    /// Controller for search history.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/history")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly ISearchHistoryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchHistoryController"/> class.
        /// </summary>
        /// <param name="service">The search history service.</param>
        public SearchHistoryController(ISearchHistoryService service)
        {
            _service = service;
        }


        /// <summary>
        /// Gets the last search for user with id <see cref="userId"/>.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(object), Description = "The last search for this user doesn't exist")]
        [HttpGet, Route("")]
        public async Task<IActionResult> GetLastSearch(string userId)
        {
            var result = await _service.GetLastSearch(userId);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}