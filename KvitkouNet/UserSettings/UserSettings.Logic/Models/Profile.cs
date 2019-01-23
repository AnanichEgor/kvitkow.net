using System.Collections;
using System.Collections.Generic;

namespace UserSettings.Logic.Models
{
	/// <summary>
	/// Класс настроек пользователя
	/// </summary>
	public class Profile
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
		public byte[] UserImage { get; set; }

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
		/// Предпочитаемое место посещения
		/// </summary>
		public string PreferPlace { get; set; }

		///// <summary>
		///// Уведомления которые будут отправлятся на почту
		///// </summary>
		//public List<string> Notifications { get; set; }
	}
}
