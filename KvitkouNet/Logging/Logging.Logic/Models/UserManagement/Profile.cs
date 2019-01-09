using System;

namespace Logging.Logic.Models.UserManagement
{
	public class Profile
	{
		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime Birthday { get; set; }
	}
}

