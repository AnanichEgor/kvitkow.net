using System;
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
		/// <param name="account"></param>
		/// <returns></returns>
		Task<ActionResult> UpdatePassword(string current, string newPass, string confirm);

		/// <summary>
		/// Обновление почты.
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		Task<ActionResult> UpdateEmail(string email);
	}
}
