using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models
{
	/// <summary>
	/// Класс настроек пользователя
	/// </summary>
	public class UserSettings
	{
		//TODO: object - заменить на User
		/// <summary>
		/// Базовые свойства конретного пользователя.
		/// </summary>
		public object User { get; set; }

		//TODO: связать с User.FirstName
		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName { get; set; }

		//TODO: связать с User.MiddleName
		/// <summary>
		/// Отчество
		/// </summary>
		public string MiddleName { get; set; }

		//TODO: связать с User.LastName
		/// <summary>
		/// Фамилия
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Аватарка пользователся
		/// </summary>
		public UserImage UserImage { get; set; }

		/// <summary>
		/// Логин пользователя. Доступен только для просмотра.
		/// </summary>
		public string Login { get; private set; }

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

		//TODO: object - заменить на класс статистики
		/// <summary>
		/// Статистика билетов пользователя.
		/// </summary>
		public object GetTicketStatistic { get; set; }

		//TODO: связать с User.Email
		/// <summary>
		/// Почта пользователя.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Флаг, отвечающий за то что было выбрано изменение пароля.
		/// </summary>
		public bool IsChangePassword { get; set; }
	}
}
