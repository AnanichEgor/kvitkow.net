using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.UserManagement;
using KvitkouNet.Logic.Common.Services.User;
using KvitkouNet.Web.Models;
using KvitkouNet.Web.Models.UserManagement;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace KvitkouNet.Web.Controllers
{
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
        /// ��������� ���� ������������� � �������
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("all")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserModelForView>), Description = "All Ok")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = Task.FromResult(new List<UserModelForView> { new UserModelForView { UserLogin = "Fake1" },
                                                               new UserModelForView { UserLogin = "Fake2" },
                                                               new UserModelForView { UserLogin = "Fake3" }
                                                             });
            return Ok(await result);
        }

        /// <summary>
        /// ��������� ������������ �� ������
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpGet, Route("{userLogin}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User is returned")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> GetUserByLogin(string userLogin)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// ���������� ������������ �� ������
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPut, Route("{userLogin}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid model")]
        public async Task<IActionResult> UpdateUser(string userLogin, [FromBody] UserModelForUpdate userModel)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }

        /// <summary>
        /// �������� ������������ �� ������
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpDelete, Route("{userLogin}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "User delete")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Invalid login")]
        public async Task<IActionResult> DeleteUser(string userLogin)
        {
            var result = Task.FromResult(true);
            return Ok(await result);
        }
    }
}