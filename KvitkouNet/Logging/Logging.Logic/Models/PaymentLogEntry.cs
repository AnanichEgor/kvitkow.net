using Logging.Logic.Models.Abstraction;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Модель для записи в лог информации о платежах
	/// </summary>
	public class PaymentLogEntry : BaseLogEntry
	{
	    /// <summary>
	    /// Id отправителя денег
	    /// </summary>
	    public string SenderId { get; set; }

	    /// <summary>
	    /// Id получателя денег
	    /// </summary>
	    public string ReciverId { get; set; }

	    /// <summary>
	    /// Сумма перевода
	    /// </summary>
	    public decimal Transfer { get; set; }
    }
}
