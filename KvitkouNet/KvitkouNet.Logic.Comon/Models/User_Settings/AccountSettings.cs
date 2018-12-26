using System;

namespace KvitkouNet.Logic.Common.Models
{
	/// <summary>
	/// Обновление аккаунта
	/// </summary>
	public class AccountSettings
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public string UserId { get; set; }

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

		/// <summary>
		/// Почта пользователя.
		/// </summary>
		public string Email { get; set; }
	}
}
