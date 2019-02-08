using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Chat.Logic.Models;
using Chat.Logic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Chat.Web.Controllers
{
    /// <summary>
    /// Контроллер
    ///  </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Получение пользовательских настроек для чата.
        /// </summary>
        /// <param name="uid">Id пользователя</param>
        /// <returns>Модель Settings</returns>
        [HttpGet, Route("settings/{uid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Settings), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings([FromRoute] string uid)
        {
            var result = await _chatService.GetUserSettings(uid);
            if (result == null)
            {
                return BadRequest("The user not exist");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Изменение пользовательских настроек
        /// </summary>
        [HttpPatch, Route("settings/{uid}")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "User Settings is updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> EditUserSettings([FromRoute] string uid, [FromBody] Settings settings)
        {
            try
            {
                await _chatService.EditUserSettings(uid, settings);
            }

            catch (InvalidDataException)
            {
                return BadRequest("The user not exist");
            }

            return NoContent();
        }
    }
}
