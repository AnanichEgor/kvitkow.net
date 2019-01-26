using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Chat.Logic.Models;
using Chat.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Chat.Web.Controllers
{
    /// <summary>
    /// Контроллер
    ///  </summary>
    [Route("api/chat/rooms")]

    public class RoomController : Controller
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        /// <summary>
        /// Получение доступных комнат для пользователя
        /// </summary>
        [HttpGet, Route("users/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms([FromRoute] string uid)
        {
            var result = await _roomService.GetRooms(uid);
            return Ok(result);
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        [HttpPost, Route("room/{uid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddRoom([FromBody] Room room, [FromRoute] string uid)
        {
            await _roomService.AddRoom(room, uid);
            return NoContent();
        }
        /// <summary>
        /// Поиск комнаты по названию.
        /// </summary>
        [HttpGet, Route("{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchRoom([FromRoute] string template)
        {
            var result = await _roomService.SearchRoom(template);
            if (result == null)
            {
                return BadRequest("The room not exist");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории.
        /// </summary>
        [HttpGet, Route("{rid}/messages/{uid}/history")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessages([FromRoute] string rid, [FromRoute] string uid)
        {
            var result = await _roomService.GetMessages(rid, uid);
            if (result == null)
            {
                return BadRequest("The room not exist messages");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Поиск сообщения в комнате по шаблону.
        /// </summary>
        [HttpGet, Route("{rid}/messages/{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchMessage([FromRoute] string rid, [FromRoute] string template)
        {
            var result = await _roomService.SearchMessage(rid, template);
            if (result == null)
            {
                return BadRequest("The message not exist");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("{rid}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message, [FromRoute] string rid)
        {
            await _roomService.AddMessage(message, rid);
            return NoContent();
        }

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPatch, Route("{rid}/mesagge")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditMessage([FromBody] Message message, [FromRoute] string rid)
        {
            await _roomService.EditMessage(message, rid);
            return NoContent();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("{rid}/mesagges/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage([FromRoute] string rid, [FromRoute] string mid)
        {
            await _roomService.DeleteMessage(rid, mid);
            return NoContent();
        }

        /// <summary>
        /// Проставить признак прочитанного сообщения
        /// </summary>
        [HttpPatch, Route("{rid}/mesagges/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditSettingsForMessage([FromRoute] string rid, [FromRoute] string mid)
        {
            await _roomService.EditSettingIsReeadForMessage(rid, mid);
            return NoContent();
        }
    }
}
