using Logging.Logic.Common.Models.Abstraction;
using Logging.Logic.Common.Models.Mocks;

namespace Logging.Logic.Common.Models
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
