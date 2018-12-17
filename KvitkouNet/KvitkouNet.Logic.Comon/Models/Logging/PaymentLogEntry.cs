using KvitkouNet.Logic.Common.Models.Logging.Abstraction;
using KvitkouNet.Logic.Common.Models.Logging.Mocks;

namespace KvitkouNet.Logic.Common.Models.Logging
{
	/// <summary>
	/// Модель для записи в лог информации о платежах
	/// В случае неудачи причина пишется в поле Content класса BaseLogEntry
	/// </summary>
	public class PaymentLogEntry : BaseLogEntry<long>
	{
		/// <summary>
		/// Модель платежной транзакции
		/// </summary>
		public PaymentTransactionMock PaymentTransaction { get; set; }
	}
}
