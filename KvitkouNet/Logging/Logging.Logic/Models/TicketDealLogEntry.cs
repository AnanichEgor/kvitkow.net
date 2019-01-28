using Logging.Data.Enums;
using Logging.Logic.Models.Abstraction;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Модель записи в лог о сделке по билету
	/// </summary>
	public class TicketDealLogEntry : BaseTicketLogEntry
	{
	    /// <summary>
	    /// Пользователь-владелец, разместивший билет
	    /// </summary>
	    public string OwnerId { get; set; }

	    /// <summary>
	    /// Покупатель/получатель билета
	    /// </summary>
	    public string RecieverId { get; set; }

	    /// <summary>
	    /// Цена билета, т.е. сумма сделки
	    /// </summary>
	    public double? Price { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public DealType Type { get; set; }
	}
}
