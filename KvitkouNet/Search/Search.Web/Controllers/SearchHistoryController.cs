using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Search.Data.Models;
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
        /// Gets the last ticket search for user with id <see cref="userId"/>.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        [SwaggerResponse(HttpStatusCode.OK, typeof(TicketSearchEntity), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(object), Description = "The last search for this user doesn't exist")]
        [HttpGet, Route("tickets")]
        public async Task<IActionResult> GetLastTicketSearch(string userId)
        {
            var result = await _service.GetLastTicketSearchAsync(userId);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        /// <summary>
        /// Gets the last user search for user with id <see cref="userId"/>.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        [SwaggerResponse(HttpStatusCode.OK, typeof(UserSearchEntity), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(object), Description = "The last search for this user doesn't exist")]
        [HttpGet, Route("users")]
        public async Task<IActionResult> GetLastUserSearch(string userId)
        {
            var result = await _service.GetLastUserSearchAsync(userId);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}