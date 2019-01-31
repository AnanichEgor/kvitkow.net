using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.UserSettings
{
	public class GetUserProfileMessage
	{
		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество пользователя
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// Фамилия пользователя
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime Birthday { get; set; }

		/// <summary>
		/// Настройки пользователя
		/// </summary>
		public string UserSettingsId { get; set; }
	}
}
