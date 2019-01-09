using Logging.Data.Enums;
using Logging.Logic.Models.Abstraction;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Модель записи в лог о действии с билетом
	/// </summary>
	public class TicketActionLogEntry : BaseTicketLogEntry
	{
		/// <summary>
		/// Тип действия с билетом
		/// </summary>
		public TicketAction Action { get; set; }
	}
}
