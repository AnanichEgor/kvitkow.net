using System;

namespace Logging.Logic.Common.Models.Abstraction
{
	/// <summary>
	/// Базовый класс для создания доменных моделей записей лога
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class BaseLogEntry<T> where T : struct
	{
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public T Id { get; set; }

		/// <summary>
		/// Дополнительное содержимое записи
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Дата создания записи
		/// </summary>
		public DateTime Created { get; set; }
	}
}
