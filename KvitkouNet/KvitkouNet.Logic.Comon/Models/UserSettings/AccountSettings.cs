using System;

namespace KvitkouNet.Logic.Common.Models
{
	/// <summary>
	/// Класс для изменения данных пользователя
	/// </summary>
	public class AccountSettings
	{
		/// <summary>
		/// Базовые свойства конретного пользователя.
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
