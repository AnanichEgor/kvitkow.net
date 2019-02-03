using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EasyNetQ;
using KvitkouNet.Messages.TicketManagement;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Search.Logic.Common.Fakers;
using Search.Logic.Common.Models;
using Search.Logic.Services;

namespace Search.Web.Controllers
{
    /// <summary>
    /// Controller for search domain.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/search")]
    public class SearchController : Controller
    {
        private readonly ISearchUserService _userService;
        private readonly ISearchTicketService _ticketService;
        private readonly IBus _bus;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="ticketService">The ticket service.</param>
        public SearchController(ISearchUserService userService, ISearchTicketService ticketService, IBus bus)
        {
            _userService = userService;
            _ticketService = ticketService;
            _bus = bus;
        }

        /// <summary>
        /// Searches the tickets.
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpGet, Route("tickets")]
        public async Task<IActionResult> SearchTickets(TicketSearchRequest request)
        {
            SearchResult<TicketInfo> result = await _ticketService.Search(request);
            return Ok(result);
        }

        /// <summary>
        /// Searches the users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpGet, Route("users")]
        public async Task<IActionResult> SearchUsers(UserSearchRequest request)
        {
            SearchResult<UserInfo> result = await _userService.Search(request);
            return Ok(result);
        }

        /// <summary>
        /// Searches the tickets.
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpPost, Route("pushTicket")]
        public ActionResult PushTicket()
        {
            _bus.Publish(TicketCreationMessageFaker.Generate(1).First());
            return Ok();
        }

        /// <summary>
        /// Searches the tickets.
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, typeof(object), Description = "All OK")]
        [HttpPost, Route("pushUser")]
        public ActionResult PushUser()
        {
            _bus.Publish(UserCreationMessageFaker.Generate(1).First());
            return Ok();
        }

    }
}