using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Search;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpGet, Route("tickets")]
        public async Task<IActionResult> GetSearchTicketResult(TicketSearchRequest request)
        {
            // SearchResult<TicketInfo> result = await _service.Get(request);
            var result = new SearchResult<TicketInfo>()
            {
                Items = Array.Empty<TicketInfo>(),
                Total = 10
            };

            return Ok(result);
        }


        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpGet, Route("users")]
        public async Task<IActionResult> GetSearchUserResult(UserSearchRequest request)
        {
            //SearchResult<UserInfo> result = await _service.Get(request);
            var result = new SearchResult<UserInfo>()
            {
                Items = Array.Empty<UserInfo>(),
                Total = 2
            };

            return Ok(result);
        }
    }
}