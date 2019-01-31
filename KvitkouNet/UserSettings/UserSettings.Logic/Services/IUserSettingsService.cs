using System;
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
		Task<bool> UpdateProfile(string id, string first, string middle, string last);

		/// <summary>
		/// Обновление пароля.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="newPass"></param>
		/// <param name="confirm"></param>
		/// <returns></returns>
		Task<bool> UpdatePassword(string id, string current, string newPass, string confirm);

		/// <summary>
		/// Обновление почты.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		Task<bool> UpdateEmail(string id, string email);

		Task<IEnumerable<Settings>> ShowAll();

		Task<bool> CheckExistEmail(string email);

		Task<bool> UpdateNotifications(string id, Notifications notifications);

		Task<bool> UpdatePreferences(string id, string address, string region, string place);

		Task<bool> DeleteAccount(string id);
	}
}
