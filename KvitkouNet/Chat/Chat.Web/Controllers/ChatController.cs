﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Chat.Logic.Models;
using Chat.Logic.Models.ChatSettings;
using Chat.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Chat.Web.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за выполняемые действия с чатом
    ///  </summary>
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Получение пользовательских настроек для чата
        /// </summary>
        [HttpGet, Route("settings/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Settings), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings([FromRoute] string uid)
        {
            var result = _chatService.GetUserSettings(uid);
            return Ok(await result);
        }


        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        [HttpPatch, Route("settings/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditUserSettings([FromRoute] string uid, [FromBody] Settings settings)
        {
            await _chatService.EditUserSettings(uid, settings);
            return NoContent();
        }

        /// <summary>
        /// Изменение роли пользователя в чате
        /// </summary>
        [HttpPatch, Route("users/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditUserRole([FromRoute] string uid, [FromBody] User settings)
        {
            await _chatService.EditUserRole(uid, settings);
            return NoContent();
        }

        /// <summary>
        /// Получение доступных комнат для пользователя
        /// </summary>
        [HttpGet, Route("rooms/users/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms([FromRoute] string uid)
        {
            var result = _chatService.GetRooms(uid);
            return Ok(await result);
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        [HttpPost, Route("romms/room/{uid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddRoom([FromBody] Room room, [FromRoute] string uid)
        {
            await _chatService.AddRoom(room, uid);
            return NoContent();
        }

        /// <summary>
        /// Поиск комнаты по названию.
        /// </summary>
        [HttpGet, Route("rooms/{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchRoom([FromRoute] string template)
        {
            var result = _chatService.SearchRoom(template);
            return Ok(await result);
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории.
        /// </summary>
        [HttpGet, Route("romms/{rid}/messages")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom([FromRoute] string rid)
        {
            var result = _chatService.GetMessagesFromTheRoom(rid);
            return Ok(await result);
        }

        /// <summary>
        /// Поиск сообщения в комнате.
        /// </summary>
        [HttpGet, Route("romms/{rid}/messages/{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchMessage([FromRoute] string rid, [FromRoute] string template)
        {
            var result = _chatService.SearchMessage(rid, template);
            return Ok(await result);
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("romms/{rid}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message, [FromRoute] string rid)
        {
            await _chatService.AddMessage(message, rid);
            return NoContent();
        }

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPatch, Route("romms/{rid}/mesagge")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditMessage([FromBody] Message message, [FromRoute] string rid)
        {
            await _chatService.EditMessage(message, rid);
            return NoContent();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("romms/{rid}/mesagges/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage([FromRoute] string rid, [FromRoute] string mid)
        {
            await _chatService.DeleteMessage(rid, mid);
            return NoContent();
        }

        /// <summary>
        /// Проставить признак прочитанного сообщения
        /// </summary>
        [HttpPatch, Route("romms/{rid}/mesagges/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditSettingsForMessage([FromRoute] string rid, [FromRoute] string mid)
        {
            await _chatService.EditSettingsForMessage(rid, mid);
            return NoContent();
        }
    }
}
