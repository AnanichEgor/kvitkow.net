using KvitkouNet.Logic.Common.Models.Ticket;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    /// Контроллер, упраляющий запросами касающихся билетов
    /// </summary>
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        /// <summary>
        /// Добавляет билет
        /// </summary>
        /// <param name="ticketModel">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
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

        /// <summary>
        /// Обновление информации о билете
        /// </summary>
        /// <param name="ticketModel">Модель билета</param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ticket update")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketModel ticketModel)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Tickets delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> DeleteAllTickets()
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Удаление билета с определенным Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ticket delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> DeleteTicket([FromBody] Guid ticketIdGuid)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(TicketModel), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = Task.FromResult(new List<TicketModel> { new TicketModel { Name = "Fake" } });
            return Ok(await result);
        }

        /// <summary>
        /// Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(TicketModel), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetTicket([FromBody] Guid ticketIdGuid)
        {
            var result = Task.FromResult(new TicketModel { Name = "Fake" });
            return Ok(await result);
        }

        /// <summary>
        /// Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("actual")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(TicketModel), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllTicketsActual()
        {
            var result = Task.FromResult(new TicketModel { Name = "Fake" });
            return Ok(await result);
        }
    }
}