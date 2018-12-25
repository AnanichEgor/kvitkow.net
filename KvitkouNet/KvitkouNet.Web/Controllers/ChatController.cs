﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Chat.ChatSettings;
using KvitkouNet.Logic.Common.Models.Security;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using KvitkouNet.Web.Models.Chat;
using KvitkouNet.Logic.Common.Services.Chat;


namespace KvitkouNet.Web.Controllers
{    
    /// <summary>
    /// Контроллер, отвечающий за выполняемые действия с чатом
    ///  </summary>
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private IChatService _securityService;

        public ChatController(IChatService securityService)
        {
            _securityService = securityService;
        }
        /// <summary>
        /// Получение пользовательских настроек для чата
        /// </summary>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Settings>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings([FromBody] int userId)
        {
            var result = _securityService.GetUserSettings(userId);
            return Ok(await result);
        }

        ///// <summary>
        ///// Получение доступных комнат для пользователя согласно его роли
        ///// </summary>
        //[HttpPost, Route("rooms")]
        //[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        //[SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        //public async Task<IActionResult> GetRooms([FromBody] int userId)
        //{
        //    var result = _securityService.GetRooms(userId);
        //    return Ok(await result);
        //}

        /// <summary>
        /// Получение сообщений из комнаты, согласно ограничению по истории
        /// </summary>
        [HttpPost, Route("romms/name")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom([FromBody] string name)
        {
            var result = _securityService.GetMessagesFromTheRoom(name);
            return Ok(await result);
        }


    }
}
