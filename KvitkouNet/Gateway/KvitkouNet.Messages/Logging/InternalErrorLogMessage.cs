﻿using System;

namespace KvitkouNet.Messages.Logging
{
	/// <summary>
	/// Модель для сообщении об ошибках на микросервисе
	/// </summary>
	public class InternalErrorLogMessage
	{
		/// <summary>
		/// Имя микросервиса
		/// </summary>
		public string ServiceName { get; set; }

		/// <summary>
		/// Название типа исключения
		/// </summary>
		public string TypeName { get; set; }

		/// <summary>
		/// Числовое значение, ассоциированное с типом исключения
		/// </summary>
		public int HResult { get; set; }

		/// <summary>
		/// Дата создания записи
		/// </summary>
		public DateTime Created { get; set; } = DateTime.Now;

		/// <summary>
		/// Строковое представление вложенных исключений
		/// </summary>
		public string InnerExceptionString { get; set; }

		/// <summary>
		/// Сообщение, описывающее исключение
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Источник исключения
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// Трассировка стека вызовов
		/// </summary>
		public string StackTrace { get; set; }

		/// <summary>
		/// Имя метода, вызвавшего исключение
		/// </summary>
		public string TargetSiteName { get; set; }
	}
}