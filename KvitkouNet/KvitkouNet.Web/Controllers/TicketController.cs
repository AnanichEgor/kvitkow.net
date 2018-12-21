using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Ticket;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    ///     Контроллер, упраляющий запросами касающихся билетов
    /// </summary>
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        [HttpPost]
        [Route("add")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(object), Description = "Ticket created")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Add([FromBody] Ticket ticket)
        {
            var result = Task.FromResult(ModelState.IsValid);
            return await result
                ? (IActionResult) Created(ticket.TicketId, ticket)
                : BadRequest("Model not valid");
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ticket update")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Ticket ticket)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Tickets delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> DeleteAll()
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ticket delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Ticket>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAll()
        {
            var result = Task.FromResult(new List<Ticket> {new Ticket {Name = "Fake"}});
            return Ok(await result);
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <param name="ticketIdGuid">Id билета</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Ticket), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = Task.FromResult(new Ticket {Name = "Fake"});
            return Ok(await result);
        }

        /// <summary>
        ///     Получение только актуальных билетов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("actual")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Ticket>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllActual()
        {
            var result = Task.FromResult(new List<Ticket> {new Ticket {Name = "Fake"}});
            return Ok(await result);
        }
    }
}