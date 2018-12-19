using KvitkouNet.Logic.Common.Models.Ticket;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        [HttpPost]
        [Route("add")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(object), Description = "Ticket created")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddTicket([FromBody] TicketModel ticketModel)
        {
            var result = Task.FromResult(ModelState.IsValid);
            return await result
                ? (IActionResult)Created(ticketModel.TicketId.ToString(), ticketModel)
                : BadRequest("Model not valid");
        }
    }
}