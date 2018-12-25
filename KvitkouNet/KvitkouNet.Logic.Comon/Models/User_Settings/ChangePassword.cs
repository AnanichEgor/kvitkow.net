using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models
{
	/// <summary>
	/// Класс для изменения данных пользователя
	/// </summary>
	public class ChangePassword
	{
		/// <summary>
		/// Настройки пользователя в которые сохранятся изменения.
		/// </summary>
		private UserSettings _userSetting;

		public ChangePassword(UserSettings settings)
		{
			_userSetting = settings;
		}
		
		/// <summary>
		/// Текущий пароль пользователя.
		/// </summary>
		public string OldPassword { get; set; }

		/// <summary>
		/// Новый пароль.
		/// </summary>
		public string NewPassword { get; set; }

		/// <summary>
		/// Подтверждение нового пароля.
		/// </summary>
		public string ConfirmPassword { get; set; }

	}
}
