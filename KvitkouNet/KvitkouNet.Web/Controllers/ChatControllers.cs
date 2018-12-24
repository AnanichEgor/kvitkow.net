using System;
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

namespace KvitkouNet.Web.Controllers
{    
    /// <summary>
    /// Контроллер, отвечающий за выполняемые действия с чатом
    ///  </summary>
    [Route("api/chat")]
    public class ChatControllers : Controller
    {
        /// <summary>
        /// Отдаем пользователю его настройки для чата
        /// </summary>
        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Settings>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetUserSettings([FromBody] int userId)
        {
            var result = Task.FromResult(new Settings
            {
                Id = userId,
                Role = new Role().Name, 
                BackgroundColor = BackgroundColor.Green,
                HideChat = HideChat.NotHidden, 
                HistoryCountsMessages = 100,
                Sound = Sound.On,
                Tab = Tab.InAMainTab,
                Toast = Toast.On,
                ViewTimestampsMessage = ViewTimestampsMessage.On
            } );
            return Ok(await result);
        }

        /// <summary>
        /// Отдаем список доступных комнат для пользователя согласно его роли
        /// </summary>
        [HttpPost, Route("rooms")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Room>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetRooms([FromBody] int userId)
        {
            var result = Task.FromResult(new List<Room>()
            {
                new Room(){Name = "Main Room"},
                new Room(){Name = "Test 1 Room"}

            });
            return Ok(await result);
        }


        /// <summary>
        /// При входе в комнату, отдадим все сообщения пользователю, согласно ограничению по истории
        /// </summary>
        [HttpPost, Route("romms/name")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetMessagesFromTheRoom([FromBody] string name)
        {
            var result = Task.FromResult(new List<Message>
            {
                new Message {UserName = "Андрей", Sended = DateTime.Now, Text = "Тестовое сообщение 1"},
                new Message {UserName = "Артем", Sended = DateTime.Now, Text = "Тестовое сообщение 2" }
            });
            return Ok(await result);
        }



    }
}
