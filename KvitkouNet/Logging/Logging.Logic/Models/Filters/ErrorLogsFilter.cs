using System;
using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
    /// <summary>
    /// Фильтр для получения логов об ошибках
    /// </summary>
	public class ErrorLogsFilter : BaseLogFilter
    {
        /// <summary>
        /// Название типа исключения
        /// </summary>
		public string ExceptionTypeName { get; set; }
	}
}
