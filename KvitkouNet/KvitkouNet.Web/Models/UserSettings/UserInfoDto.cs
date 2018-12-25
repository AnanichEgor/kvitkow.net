using System;
using System.Collections.Generic;

namespace KvitkouNet.Web.Models
{
	/// <summary>
	/// Общая информация о пользователе
	/// </summary>
	public class UserInfoDto
	{
		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// Фамилия
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Аватарка пользователся
		/// </summary>
		public object UserImage { get; set; }

		/// <summary>
		/// Дата рождения 
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// Мобильный телефон
		/// </summary>
		public string Number { get; set; }
	}
}
