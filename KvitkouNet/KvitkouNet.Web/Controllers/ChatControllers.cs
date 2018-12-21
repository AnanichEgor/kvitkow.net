using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Web.Models.Chat;
using KvitkouNet.Logic.Common.Models.Security;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    [Route("api/chat")]
    public class ChatControllers : Controller
    {
        [HttpGet, Route("all/messages")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Message>), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, typeof(void), Description = "Requires authentication")]
        public async Task<IActionResult> GetAllMessages()
        {
            var result = Task.FromResult(new List<Message>
            {
                new Message { Id = 1, Massage = "Тестовое сообщение 1", Sended = DateTime.Now , UserName = "Андрей"},
                new Message { Id = 1, Massage = "Тестовое сообщение 2", Sended = DateTime.Now , UserName = "Артем"}
            });
            return Ok(await result);
        }
    }
}
