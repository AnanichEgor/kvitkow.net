﻿using System.Threading.Tasks;
using AdminPanel.Logic.Dtos.UserManagement;
using AdminPanel.Logic.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
	/// <summary>
	/// Контроллер для работы с пользователями через панель администратора
	/// </summary>
	[Route("api/admin/users")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		/// <summary>
		/// Получает пользователей для просмотра с помощью панели администратора
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _userService.GetAll();
			return Ok(result);
		}

		[HttpPatch]
		[Route("ban/")]
		public async Task<IActionResult> ChangeIsBannedStatus([FromBody] IsBannedDto dto)
		{
			await _userService.ChangeIsBannedStatus(dto);
			return NoContent();
		}
	}
}