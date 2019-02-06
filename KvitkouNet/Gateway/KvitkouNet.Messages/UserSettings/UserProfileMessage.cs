using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Messages.UserSettings
{
	public class UserProfileMessage
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
		/// Телефоны пользователя
		/// </summary>
		public IEnumerable<string> PhoneNumber { get; set; }

		public string SettingsId { get; set; }
	}
}
