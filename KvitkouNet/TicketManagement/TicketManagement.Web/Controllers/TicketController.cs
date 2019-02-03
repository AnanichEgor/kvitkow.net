using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Models.Enums;
using TicketManagement.Logic.Services;

namespace TicketManagement.Web.Controllers
{
    /// <summary>
    ///     Контроллер, упраляющий запросами касающихся билетов
    /// </summary>
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Добавляет билет
        /// </summary>
        /// <param name="ticket">Модель билета</param>
        /// <returns>Код ответа Create и добавленную модель</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "Ticket created")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "User rating is negative")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(string), Description = "Unauthorized user")]
        public async Task<IActionResult> Add([FromBody] Ticket ticket)
        {
            var result = await _service.Add(ticket);
            if (result.Item2 == RequestStatus.InvalidModel) return ValidationProblem();
            if (result.Item2 == RequestStatus.BadUserRating) return StatusCode(403);
            if (result.Item2 == RequestStatus.Error) return StatusCode(500);
            return Ok(result.Item1);
        }

        /// <summary>
        ///     Добавление пользователя в "я пойду"
        /// </summary>
        /// <param name="id">id билета</param>
        /// <param name="user">Пользователь добавивший билет</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/add")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(bool), Description = "Ticket update")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddRespondedUsers([FromRoute] string id, [FromBody] UserInfo user)
        {
           var res= await _service.AddRespondedUsers(id, user);
           if (res != RequestStatus.Success) return BadRequest();
           return NoContent();
        }

        /// <summary>
        ///     Обновление информации о билете
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket">Модель билета</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(bool), Description = "Ticket update")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Ticket ticket)
        {
           var res= await _service.Update(id, ticket);
           if (res != RequestStatus.Success) return BadRequest();
           return NoContent();
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Tickets delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> DeleteAll()
        {
            var result = await _service.DeleteAll();
            return NoContent();
        }

        /// <summary>
        ///     Удаление билета с определенным Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Ticket delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _service.Delete(id);
            return NoContent();
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Ticket>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (result.Item2 != RequestStatus.Success) return BadRequest();
            return Ok(result.Item1);
        }

        /// <summary>
        ///     Получение билета по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Ticket), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = await _service.Get(id);
            return Ok(result.Item1);
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
            var result = await _service.GetAllActual();
            return Ok(result.Item1);
        }

        /// <summary>
        ///     Получение всех билет имеющихся в системе постранично
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("page/{index}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Page<TicketLite>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllPagebyPage([FromRoute] int index)
        {
            var result = await _service.GetAllPagebyPage(index);
            if (result.Item2 != RequestStatus.Success) return BadRequest();
            return Ok(result.Item1);
        }

        /// <summary>
        ///     Получение всех актуальных билетов имеющихся в системе постранично
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("actual/page/{index}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Page<TicketLite>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllPagebyPageActual([FromRoute] int index)
        {
            var result = await _service.GetAllPagebyPageActual(index);
            if (result.Item2 != RequestStatus.Success) return BadRequest();
            return Ok(result.Item1);
        }
    }
}