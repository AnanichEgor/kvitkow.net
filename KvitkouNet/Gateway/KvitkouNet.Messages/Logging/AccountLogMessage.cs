﻿using System;

using KvitkouNet.Messages.Logging.Enums;

namespace KvitkouNet.Messages.Logging
{
	/// <summary>
	/// Модель сообщения о действии с аккаунтом пользователя
	/// </summary>
	public class AccountLogMessage
	{
		/// <summary>
		/// Id записи
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Дата логируемого события
		/// </summary>
		public DateTime EventDate { get; set; }

		/// <summary>
		/// Id пользователя
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Почтовый адрес пользователя
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Тип действия
		/// </summary>
		public AccountActionType Type { get; set; }
	}
}
