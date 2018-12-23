using System.Net;
using System.Collections.Generic;
using KvitkouNet.Logic.Common.Models.Dashboard;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KvitkouNet.Web.Controllers
{
    public class DashboardController : Controller
    {
        /// <summary>
        ///     Контроллер, упраляющий новостями
        /// </summary>
        [Route("api/news")]
        public class TicketController : Controller
        {
            /// <summary>
            ///     Добавляет новость
            /// </summary>
            /// <param name="news">Модель новости</param>
            /// <returns>Код ответа Create и добавленную </returns>
            [HttpPost]
            [SwaggerResponse(HttpStatusCode.Created, typeof(object), Description = "Mews created")]
            [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
            [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
            public async Task<IActionResult> Add([FromBody] News news)
            {
                var result = Task.FromResult(ModelState.IsValid);
                return await result
                    ? (IActionResult)Created(news.NewsId, news)
                    : BadRequest("Model not valid");
            }

           
            /// <summary>
            ///     Удаление новости по Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpDelete]
            [Route("{id}")]
            [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "News delete")]
            [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
            [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Error")]
            public async Task<IActionResult> Delete([FromRoute] string id)
            {
                var result = Task.FromResult(true);
                return Ok(await result);
            }

            /// <summary>
            ///     Получение новости по Id
            /// </summary>
            /// <param name="newsIdGuid">Id новости</param>
            /// <returns></returns>
            [HttpGet]
            [Route("{id}")]
            [SwaggerResponse(HttpStatusCode.OK, typeof(News), Description = "All Ok")]
            [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
            [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
            public async Task<IActionResult> Get([FromRoute] string id)
            {
                var result = Task.FromResult(new News { Name = "Fake" });
                return Ok(await result);
            }

            /// <summary>
            ///     Обновление информации о новости
            /// </summary>
            /// <param name="id"></param>
            /// <param name="news">Модель билета</param>
            /// <returns></returns>
            [HttpPut]
            [Route("{id}")]
            [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "News update")]
            [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
            [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
            public async Task<IActionResult> Update([FromRoute] string id, [FromBody] News news)
            {
                var result = Task.FromResult(true);
                return Ok(await result);
            }

        }

    }
}
