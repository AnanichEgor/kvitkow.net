using Logging.Logic.Models.Mocks;
using Logging.Logic.Models.UserManagement;

namespace Logging.Logic.Models.Abstraction
{
	/// <summary>
	/// Базовый класс для создание доменных моделей записей лога о билетах
	/// </summary>
	public abstract class BaseTicketLogEntry : BaseLogEntry
	{
		/// <summary>
		/// Билет
		/// </summary>
		public TicketMock Ticket { get; set; }

		/// <summary>
		/// Пользователь-владелец билета
		/// </summary>
		public User Owner { get; set; }
	}
}
