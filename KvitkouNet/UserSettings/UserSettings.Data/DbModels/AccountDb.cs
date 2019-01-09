using System;
using System.Collections.Generic;
using System.Text;

namespace UserSettings.Data.DbModels
{
	public class AccountDb
	{
		/// <summary>
		/// Ключ
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Id пользователя
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Почта пользователя.
		/// </summary>
		public string Email { get; set; }
	}
}
