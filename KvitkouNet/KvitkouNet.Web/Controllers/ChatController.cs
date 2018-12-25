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
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Settings>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings([FromBody] int userId)
        {
            var result = _chatService.GetUserSettings(userId);
            return Ok(await result);
        }

        /// <summary>
        /// Получение доступных комнат для пользователя согласно его роли
        /// </summary>
        [HttpPost, Route("rooms")]
        //[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms([FromBody] int userId)
        {
            //var result = _chatService.GetRooms(userId);
            return Ok(/*await result*/);
        }

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        [HttpPost, Route("romms/name")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom([FromBody] string id)
        {
            var result = _chatService.GetMessagesFromTheRoom(id);
            return Ok(await result);
        }

        /// <summary>
        /// Поиск сообщения в комнате
        /// </summary>
        [HttpPost, Route("romms/name")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> SearchMessage([FromBody] string template, string roomId)
        {
            var result = _chatService.SearchMessage(template, roomId);
            return Ok(await result);
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        [HttpPost, Route("romms/name/add")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            //var result = _chatService.AddMessage(message);
            return NoContent();
        }

        /// <summary>
        /// Редактирование сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut, Route("romms/name/edit")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(Message), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        //public async Task<IActionResult> EditMessage([FromBody] ViewMessage message)
        //{
        //    var result = _chatService.EditMessage(message);
        //    return Ok(await result);
        //}

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        [HttpDelete, Route("romms/name/delete")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(string), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> DeleteMessage([FromBody] string messageId)
        {
            var result = _chatService.DeleteMessage(messageId);
            return NoContent();
        }

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        [HttpPut, Route("settings/backgroundColor/edit")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditSettings([FromBody] Settings settings)
        {
            var result = _chatService.EditSettings(settings);
            return Ok(await result);
        }

    }
}
