using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Security;
using KvitkouNet.Logic.Common.Services.Statistics;
using KvitkouNet.Logic.Common.Models.Statistic;
using KvitkouNet.Logic.Common.Models.UserManagement;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    /// Controller, which provides statistics to user
    /// </summary>
    [Route("api/statistics")]
    public class StatisticsController:Controller
    {
        IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet, Route("own")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> GetOwnStatistic()
        {
            var result = _statisticService.GetOwnStatistic();
            return Ok(await result);
        }

        [HttpGet, Route("own/realised/add/ticket")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> AddRealisedTicket([FromBody] Offer offer)
        {
            var result = _statisticService.AddRealisedTicket(offer);
            return Ok(await result);
        }

        [HttpPost, Route("own/donated/add/ticket")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> AddDonatedTicket([FromBody] Offer offer)
        {
            var result = _statisticService.AddDonatedTicket(offer);
            return Ok(await result);
        }

        [HttpGet, Route("own/offers")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> EditTotalOffers()
        {
            var result = _statisticService.EditTotalOffers();
            return Ok(await result);
        }

        [HttpGet, Route("own/blacklist")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> EditBlackList()
        {
            var result = _statisticService.EditBlackList();
            return Ok(await result);
        }

        [HttpPost, Route("own/blacklist/add/{userid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> AddToBlackList([FromBody] User user)
        {
            var result = _statisticService.AddToBlackList(user);
            return Ok(await result);
        }

        [HttpPost, Route("own/blacklist/delete/{userid}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(OwnStatistic), Description = "OK")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access denied")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = "Error. Try Again")]

        public async Task<IActionResult> DeleteFromBlackList([FromBody] User user)
        {
            var result = _statisticService.DeleteFromBlackList(user);
            return Ok(await result);
        }

    }
}
