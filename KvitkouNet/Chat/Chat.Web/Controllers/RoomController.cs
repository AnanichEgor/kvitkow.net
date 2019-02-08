﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Chat.Logic.Models;
using Chat.Logic.Services;
using EasyNetQ;
using KvitkouNet.Messages.Chat;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Chat.Web.Controllers
{
    /// <summary>
    /// Контроллер
    ///  </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/chat/rooms")]

    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private readonly IBus _bus;

        public RoomController(IRoomService roomService, IBus bus)
        {
            _roomService = roomService;
            _bus = bus;
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
            if(result.Count() != 0)
            return Ok(result);

            return BadRequest("No rooms");
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        [HttpPost, Route("room/{uid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "Room created!")]
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
            if (result.Count() != 0)
                return Ok(result);

            return BadRequest("No rooms");
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории.
        /// </summary>
        [HttpGet, Route("{rid}/messages/history/{historyCountsMessages}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessages([FromRoute] string rid, [FromRoute] int historyCountsMessages)
        {
            var result = await _roomService.GetMessages(rid, historyCountsMessages);
            if (result.Count() != 0)
                return Ok(result);

            return BadRequest("The room not exist messages");
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
            if (result.Count() != 0)
                return Ok(result);

            return BadRequest("The message not exist");
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("{rid}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "Message sended")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message, [FromRoute] string rid)
        {
            var nameUserIsOffline = await _roomService.AddMessage(message, rid);

            //Если пользователь Offline отправим ему уведомление
            if (nameUserIsOffline != null)
            {

                await _bus.PublishAsync(new OfflineChatMessage
                {
                    UserName = nameUserIsOffline,
                    SendedTime = message.SendedTime
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        [HttpPatch, Route("{rid}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "Message updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditMessage([FromBody] Message message, [FromRoute] string rid)
        {
            try
            {
                await _roomService.EditMessage(message, rid);
            }

            catch (InvalidDataException)
            {
                return BadRequest("The message not exist");
            }

            return NoContent();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("messages/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "Message deleted")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage([FromRoute] string mid)
        {
            await _roomService.DeleteMessage(mid);
            return NoContent();
        }
    }
}
