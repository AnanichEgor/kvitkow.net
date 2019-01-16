using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using StatisticOnline.Logic.Interfaces;
using StatisticOnline.Logic.Models;


namespace StatisticOnline.Web.Controllers
{
    [Route("api/statistics/count")]
    public class StatistisOnlineController: ControllerBase
    {
        IStatisticOnlineService _statisticService;

        public StatistisOnlineController(IStatisticOnlineService statisticService)
        {
            _statisticService = statisticService;
        }

        /// <summary>
        /// возвращает число всех пользователей на сайте Online
        /// последняя запись из базы
        /// </summary>
        [HttpGet]
        [Route("all")]
        [SwaggerTag("Число всех пользователей на сайте Online")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OnlineModel), Description = "Number of users online")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetCountAll()
        {
            var result = await _statisticService.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// возвращает число всех пользователей на сайте Online
        /// в заданном диапазоне дат
        /// </summary>
        [HttpPost]
        [Route("range")]
        [SwaggerTag("Число всех пользователей на сайте Online в заданном диапазоне дат")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<OnlineModel>), Description = "Number of users online")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetDateRangeUsers([FromBody]DateRange model)
        {
            var result = await _statisticService.GetDateRangeUsers(model);
            return Ok(result);
        }


        /// <summary>
        /// возвращает число зарегистрированных пользователей  Online
        /// </summary>
        [HttpGet]
        [Route("registered")]
        [SwaggerTag("Число зарегистрированных пользователей  Online")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "Number of users registered online")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetCountRegistered()
        {
            var result = await _statisticService.GetRegisteredUser();
            return Ok(result);
        }

        /// <summary>
        /// возвращает число гостей на сайте Online
        /// </summary>
        [HttpGet]
        [Route("guests")]
        [SwaggerTag("Число гостей на сайте Online")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "Number of guests online")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetCountGuest()
        {
            var result = await _statisticService.GetGuestUser();
            return Ok(result);
        }
    }
}
