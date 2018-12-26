﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models
{
	public class UserSettings
	{
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

		//TODO: object - заменить на класс статистики
		/// <summary>
		/// Статистика билетов пользователя.
		/// </summary>
		public object GetTicketStatistic { get; set; }

		/// <summary>
		/// Флаг, отвечающий за то что было выбрано изменение пароля.
		/// </summary>
		public bool IsChangePassword { get; set; }

		/// <summary>
		/// Предпочитаемое место посещения
		/// </summary>
		public string PreferPlace { get; set; }
	}
}
