using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Web.Models;
using KvitkouNet.Web.Models.UserManagement;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с группами пользователей
    /// </summary>
    [Route("api/groups")]
    public class UserGroupController : Controller
    {
        /// <summary>
        /// Добавление группы по id
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(object), Description = "Group Created")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Add(int id, [FromBody] UserGroupModel userGroupModel)
        {
            var result = Task.FromResult(true);
            return await result
                ? (IActionResult)Created(userGroupModel.GroupId.ToString(), userGroupModel)
                : BadRequest("Model not valid");
        }

        /// <summary>
        /// Получение всех групп пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserGroupModel>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAll()
        {
            var result = Task.FromResult(new List<UserGroupModel> { new UserGroupModel { Name = "Fake1" },
                                                               new UserGroupModel { Name = "Fake2" },
                                                               new UserGroupModel { Name = "Fake3" }
                                                             });
            return Ok(await result);
        }

        /// <summary>
        /// Получение группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group is returned")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Обновление группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UserGroupModel userModel)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Удаление группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }


        /// <summary>
        /// Получение всех пользователей группы
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{id}/allusers")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserForViewModel>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllUsersInGroup()
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }
    }
}