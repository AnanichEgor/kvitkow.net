using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using StatisticUser.Logic.DTOs;
using StatisticUser.Logic.Interfaces;

namespace StatisticUser.Web.Controllers
{
    [Route("api/statistic/user")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        IStatisticUserService _statisticService;

        public StatisticController(IStatisticUserService statisticService)
        {
            _statisticService = statisticService;
        }

        /// <summary>
        /// возвращает cтатистику посещения ресурсов сайта
        /// </summary>
        [HttpPost]
        [Route("resources")]
        [SwaggerTag("Статистика посещения ресурсов сайта")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<ITimeOnResouces>), Description = "Statistics of site resources visiting")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetTimeOnResouces([FromBody]DateRange model)
        {
            var result = await _statisticService.GetTimeOnResouces(model);
            return Ok(result);
        }
    }
}
