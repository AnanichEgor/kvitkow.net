using System;
using System.Collections.Generic;
using System.Text;

namespace UserSettings.Logic.Common.Models
{
	/// <summary>
	/// Класс настроек пользователя
	/// </summary>
	public class ProfileSettings
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
		/// Флаг, отвечающий за закрытость аккаунта для гостей.
		/// </summary>
		public bool IsPrivateAccount { get; set; }

		/// <summary>
		/// Предпочитаемый адрес доступных билетов.
		/// </summary>
		public string PreferAddress { get; set; }

		/// <summary>
		/// Предпочитаемый район доступных билетов.
		/// </summary>
		public string PreferRegion { get; set; }

		/// <summary>
		/// Флаг, отвечающий за получение информации о билетах.
		/// </summary>
		public bool IsGetTicketInfo { get; set; }

		/// <summary>
		/// Ссылки на социальные сети.
		/// </summary>
		public IEnumerable<object> SocialNetwork { get; set; }

		/// <summary>
		/// Предпочитаемое место посещения
		/// </summary>
		public string PreferPlace { get; set; }
	}
}
