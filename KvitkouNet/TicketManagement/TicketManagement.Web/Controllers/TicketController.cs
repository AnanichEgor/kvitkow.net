﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using TicketManagement.Data.Context;
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
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Add([FromBody] Ticket ticket)
        {
            var result = await _service.Add(ticket);
            if (result.Item2 == RequestStatus.BadRequest)
            {
                return BadRequest();
            }
            if (result.Item2 == RequestStatus.Error)
            {
                return StatusCode(500);
            }
            return Ok(result);
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
            await _service.Update(id, ticket);
            return NoContent();
        }

        /// <summary>
        ///     Удаление всех билетов
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Tickets delete")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
        public async Task<IActionResult> DeleteAll()
        {
            var result = _service.DeleteAll();
            return Ok();
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
            var result = _service.Delete(id);
            return Ok();
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
            if (result.Item2 != RequestStatus.Success)
            {
                return BadRequest();
            }
            return Ok(result);
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
            var result = await _service.Get(id);
            return Ok(result);
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
            return Ok(result);
        }
    }
}