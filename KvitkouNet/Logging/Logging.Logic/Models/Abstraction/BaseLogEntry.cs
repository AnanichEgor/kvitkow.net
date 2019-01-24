using System;

namespace Logging.Logic.Models.Abstraction
{
	/// <summary>
	/// Базовый класс для создания доменных моделей записей лога
	/// </summary>
	public abstract class BaseLogEntry
	{
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public string Id { get; set; }

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
