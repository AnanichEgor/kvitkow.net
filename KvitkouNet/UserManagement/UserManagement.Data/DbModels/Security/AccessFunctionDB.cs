using System.Collections.Generic;

namespace UserManagement.Data.DbModels.Security
{
    /// <summary>
    /// Функция доступа к фиче
    /// </summary>
    public class AccessFunctionDB
    {
        /// <summary>
        /// Идентификатор функции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя функции
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор фичи
        /// </summary>
        public string FeatureId { get; set; }

        /// <summary>
        /// Список прав предоставляемых функцией
        /// </summary>
        public List<AccessRightDB> AccessRights { get; set; }
    }
}
