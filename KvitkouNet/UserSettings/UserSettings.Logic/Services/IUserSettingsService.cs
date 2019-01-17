﻿using System;
using System.Threading.Tasks;
using UserSettings.Logic.Models;
using UserSettings.Logic.Models.Helper;

namespace UserSettings.Logic.Services
{
	/// <summary>
	/// Сервис для обновления настроек пользователя
	/// </summary>
	public interface IUserSettingsService : IDisposable
	{
		/// <summary>
		/// Обновление профиля.
		/// </summary>
		/// <param name="profile"></param>
		/// <returns></returns>
		Task<ActionResult> UpdateProfile(Profile profile);

		/// <summary>
		/// Обновление пароля.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="newPass"></param>
		/// <param name="confirm"></param>
		/// <returns></returns>
		Task<ActionResult> UpdatePassword(string current, string newPass, string confirm);

		/// <summary>
		/// Обновление почты.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		Task<bool> UpdateEmail(string id, string email);
	}
}
