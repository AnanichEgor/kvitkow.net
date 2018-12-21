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
    [Route("api/groups")]
    public class UserGroupController : Controller
    {
        /// <summary>
        /// Создание группы
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("add/{id}")]
        [SwaggerResponse(HttpStatusCode.Created, typeof(object), Description = "Group Created")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> AddUserGroup(int id, [FromBody] UserGroupModel userGroupModel)
        {
            var result = Task.FromResult(true);
            return await result
                ? (IActionResult)Created(userGroupModel.GroupId.ToString(), userGroupModel)
                : BadRequest("Model not valid");
        }

        /// <summary>
        /// Получение всех групп
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserGroupModel>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllGroups()
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
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet, Route("{groupId}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group is returned")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid id")]
        public async Task<IActionResult> GetGroupById(int groupId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Обновление группы по id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPut, Route("{groupId}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> UpdateGroup(int groupId, [FromBody] UserGroupModel userModel)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Удаление группы по id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{groupId}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Group delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }


        /// <summary>
        /// Получение всех пользователей группы
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{groupId}/allusers")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserModelForView>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllUsersInGroup()
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }
    }
}