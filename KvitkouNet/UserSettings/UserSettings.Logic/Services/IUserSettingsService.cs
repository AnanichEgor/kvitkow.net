﻿using System;
using System.Collections.Generic;
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
		Task<ActionResult> UpdateProfile(string id, Profile profile);

		/// <summary>
		/// Обновление пароля.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="newPass"></param>
		/// <param name="confirm"></param>
		/// <returns></returns>
		Task<ActionResult> UpdatePassword(string id, string current, string newPass, string confirm);

		/// <summary>
		/// Обновление почты.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		Task<bool> UpdateEmail(string id, string email);

		Task<IEnumerable<Settings>> ShowAll();

		/// <summary>
		/// Отправка подтверждающего email.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="subject"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		Task SendConfirmEmail(string email, string subject, string message);

		Task<bool> CheckExistEmail(string email);
	}
}
