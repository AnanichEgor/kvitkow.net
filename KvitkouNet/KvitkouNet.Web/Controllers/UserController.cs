using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.User;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost, Route("register")]
        [SwaggerResponse(HttpStatusCode.NoContent, typeof(void), Description = "All OK")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> Register([FromBody]UserRegisterModel model)
        {
            var result = await _service.Register(model);
            return Ok(result);
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<ForViewModel>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAll()
        {
            var result = Task.FromResult(new List<ForViewModel> { new ForViewModel { Login = "Fake1" },
                                                               new ForViewModel { Login = "Fake2" },
                                                               new ForViewModel { Login = "Fake3" }
                                                             });
            return Ok(await result);
        }

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpGet, Route("{login}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User is returned")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> GetByLogin(string userLogin)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Редактирование пользователя по логину
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPut, Route("{login}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> UpdateByLogin(string userLogin, [FromBody] ForUpdateModel userModel)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// Удаление пользователя по логину
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpDelete, Route("{login}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> DeleteByLogin(string userLogin)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }
    }
}