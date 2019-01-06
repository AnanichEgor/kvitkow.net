using Logging.Logic.Common.Models.Mocks;
using Logging.Logic.Common.Models.UserManagement;

namespace Logging.Logic.Common.Models.Abstraction
{
	/// <summary>
	/// Базовый класс для создание доменных моделей записей лога о билетах
	/// </summary>
	public abstract class BaseTicketLogEntry : BaseLogEntry<long>
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
