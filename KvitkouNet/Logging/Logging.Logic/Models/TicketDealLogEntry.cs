using Logging.Data.Enums;
using Logging.Logic.Models.Abstraction;
using Logging.Logic.Models.UserManagement;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Модель записи в лог о сделке по билету
	/// </summary>
	public class TicketDealLogEntry : BaseTicketLogEntry
	{
		/// <summary>
		/// Покупатель/получатель билета
		/// </summary>
		public User Reciever { get; set; }

		/// <summary>
		/// Цена билета, т.е. сумма сделки
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Тип сделки
		/// </summary>
		public DealType Type { get; set; }
	}
}
