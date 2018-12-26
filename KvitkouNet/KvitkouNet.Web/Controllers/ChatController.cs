using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Chat.ChatSettings;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using KvitkouNet.Web.Models.Chat;
using KvitkouNet.Logic.Common.Models.Chat;
using KvitkouNet.Logic.Common.Services.Chat;
using Microsoft.AspNetCore.Routing;


namespace KvitkouNet.Web.Controllers
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
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Settings), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings()
        {
            var result = _chatService.GetUserSettings((string)RouteData.Values["id"]);
            return Ok(result);
        }

        /// <summary>
        /// Получение доступных комнат для пользователя
        /// </summary>
        [HttpGet, Route("rooms/users/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms()
        {
            var result = _chatService.GetRooms((string)RouteData.Values["id"]);
            return Ok(await result);
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        [HttpGet, Route("romms/{id}/messages")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom()
        {
            var result = _chatService.GetMessagesFromTheRoom((string)RouteData.Values["id"]);
            return Ok(await result);
        }

        /// <summary>
        /// Поиск сообщения в комнате
        /// </summary>
        [HttpGet, Route("romms/{id}/messages/{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchMessage()
        {
            var result = _chatService.SearchMessage((string)RouteData.Values["template"], (string)RouteData.Values["id"]);
            return Ok(await result);
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("romms/{id}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            await _chatService.AddMessage(message);
            return NoContent();
        }

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPatch, Route("romms/{id}/mesagge")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditMessage([FromBody] MessageModel message)
        {
            var result = _chatService.EditMessage(new Message()
            {
                RoomId = (string)RouteData.Values["id"],
                Id = message.Id,
                Sended = message.Sended,
                Text = message.Text,
                UserId = message.UserId
            });
            return NoContent();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("romms/{roomid}/mesagges/{messageid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage()
        {
            var result = _chatService.DeleteMessage((string)RouteData.Values["roomid"], (string)RouteData.Values["messageid"]);
            return NoContent();
        }

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        [HttpPatch, Route("settings/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditSettings()
        {
            var result = _chatService.EditSettings((string)RouteData.Values["id"]);
            return NoContent();
        }

    }
}
