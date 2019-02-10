using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using StatisticUser.Logic.DTOs;
using StatisticUser.Logic.Interfaces;
using StatisticUser.Logic.Services;

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

        [HttpGet]
        [Route("all")]
        [SwaggerTag("Статистика по всем пользователям")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<ITimeOnResouces>), Description = "Statistics of users")]
        [SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Access error")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public object All([FromQuery] DataSourceLoadOptions loadOptions)
        {
            var  result = _statisticService.GetAllUser(loadOptions);
            return result.Result;
        }

        //[HttpGet]
        //public object Lookup([FromQuery] DataSourceLoadOptions loadOptions, [FromServices] OrganizationDbContext organizationDbContext)
        //{
        //    var data = DataSourceLoader.Load(
        //        organizationDbContext.Organizations.Select(org => new UserLookup()
        //        {
        //            Id = org.Id,
        //            Name = org.Name
        //        }),
        //        loadOptions);

        //    return data;
        //}

        //[HttpGet]
        //public object Details([FromQuery] int orderId, [FromQuery] DataSourceLoadOptions loadOptions,
        //    [FromServices] OrganizationDbContext organizationDbContext)
        //{
        //    var data = DataSourceLoader.Load(
        //        organizationDbContext.Organizations,
        //        loadOptions);

        //    return data;
        //}

        //[HttpPut]
        //public IActionResult Update([FromForm] int key, [FromForm] string values, [FromServices] OrganizationDbContext organizationDbContext)
        //{
        //    var order = organizationDbContext.Organizations.FirstOrDefault(o => o.Id == key);
        //    if (order == null)
        //        return StatusCode(409, "User not found");

        //    JsonConvert.PopulateObject(values, order);

        //    if (!TryValidateModel(order))
        //        return BadRequest("Some error");

        //    organizationDbContext.SaveChanges();

        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Insert([FromForm] string values, [FromServices] OrganizationDbContext organizationDbContext)
        //{
        //    var organization = new Organization();
        //    JsonConvert.PopulateObject(values, organization);

        //    if (!TryValidateModel(organization))
        //        return BadRequest("Some error");

        //    organizationDbContext.Organizations.Add(organization);
        //    organizationDbContext.SaveChanges();

        //    return Ok(organization);
        //}

        //[HttpDelete]
        //public IActionResult Delete([FromForm] int key, [FromServices] OrganizationDbContext organizationDbContext)
        //{
        //    var order = organizationDbContext.Organizations.FirstOrDefault(o => o.Id == key);
        //    if (order == null)
        //        return StatusCode(409, "Organizations not found");

        //    organizationDbContext.Organizations.Remove(order);
        //    organizationDbContext.SaveChanges();

        //    return Ok();
        //}




    }
}
