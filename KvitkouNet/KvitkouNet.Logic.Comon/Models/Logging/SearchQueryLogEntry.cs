using KvitkouNet.Logic.Common.Models.Logging.Abstraction;
using KvitkouNet.Logic.Common.Models.Logging.Mocks;

namespace KvitkouNet.Logic.Common.Models.Logging
{
	/// <summary>
	/// Модель для логирования поисковых запросов пользователей.
	/// Сам запрос хранится в свойстве Content класса BaseLogEntry
	/// </summary>
	public class SearchQueryLogEntry : BaseLogEntry<long>
	{
		/// <summary>
		/// Состояние фильтров при выполнении запросов
		/// </summary>
		public DashBoardFilterMock DashBoardFilter { get; set; }
	}
}
