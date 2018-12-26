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
        [HttpGet, Route("settings/{id}")]
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
        [HttpGet, Route("rooms/users/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms()
        {
            var result = _chatService.GetRooms((string)RouteData.Values["uid"]);
            return Ok(await result);
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        [HttpGet, Route("romms/{rid}/messages")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom()
        {
            var result = _chatService.GetMessagesFromTheRoom((string)RouteData.Values["rid"]);
            return Ok(await result);
        }

        /// <summary>
        /// Поиск сообщения в комнате
        /// </summary>
        [HttpGet, Route("romms/{rid}/messages/{template}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchMessage()
        {
            var result = _chatService.SearchMessage((string)RouteData.Values["rid"], (string)RouteData.Values["template"]);
            return Ok(await result);
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("romms/{rid}/message")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            await _chatService.AddMessage(message, (string)RouteData.Values["rid"]);
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
        public async Task<IActionResult> EditMessage([FromBody] Message message)
        {
            await _chatService.EditMessage(message, (string)RouteData.Values["rid"]);
            return NoContent();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("romms/{rid}/mesagges/{mid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage()
        {
            await _chatService.DeleteMessage((string)RouteData.Values["rid"], (string)RouteData.Values["mid"]);
            return NoContent();
        }

        /// <summary>
        /// Проставить признак прочитанного сообщения
        /// </summary>
        [HttpPatch, Route("romms/{rid}/mesagges/{mid}/settings")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditSettingsForMessage()
        {
            await _chatService.EditSettingsForMessage((string)RouteData.Values["rid"], (string)RouteData.Values["mid"]);
            return NoContent();
        }

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        [HttpPatch, Route("settings")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditUserSettings(Settings settings)
        {
        await _chatService.EditUserSettings(settings);
        return NoContent();
        }

    }
}
