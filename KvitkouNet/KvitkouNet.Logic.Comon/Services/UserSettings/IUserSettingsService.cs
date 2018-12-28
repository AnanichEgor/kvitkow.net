using KvitkouNet.Logic.Common.Models;
using KvitkouNet.Logic.Common.Models.UserSettings;
using System;
using System.Threading.Tasks;

namespace KvitkouNet.Logic.Common.Services.UserSettings
{
	/// <summary>
	/// Сервис для обновления настроек пользователя
	/// </summary>
	public interface IUserSettingsService: IDisposable
	{
		/// <summary>
		/// Обновление профиля.
		/// </summary>
		/// <param name="profile"></param>
		/// <returns></returns>
		Task<ActionResult> UpdateProfile(ProfileSettings profile);

		/// <summary>
		/// Обновление аккаунта.
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		Task<ActionResult> UpdateAccout(AccountSettings account);
	}
}
