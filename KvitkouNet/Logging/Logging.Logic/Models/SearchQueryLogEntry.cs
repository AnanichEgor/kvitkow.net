using Logging.Logic.Models.Abstraction;
using Logging.Logic.Models.Mocks;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Модель для логирования поисковых запросов пользователей.
	/// <para>Текст запроса хранится в свойстве Content класса BaseLogEntry.</para>
	/// </summary>
	public class SearchQueryLogEntry : BaseLogEntry<long>
	{
		/// <summary>
		/// Состояние фильтров при выполнении запросов
		/// </summary>
		public DashBoardFilterMock DashBoardFilter { get; set; }
	}
}
