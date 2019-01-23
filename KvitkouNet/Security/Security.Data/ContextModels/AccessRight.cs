using System.Collections.Generic;

namespace Security.Data.ContextModels
{
    /// <summary>
    /// Право доступа
    /// </summary>
    internal class AccessRight
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя права доступа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список прав предоставляемых функцией
        /// </summary>
        public List<AccessFunctionAccessRight> AccessFunctionAccessRights { get; set; }

        /// <summary>
        /// Список прав предоставляемых фичей
        /// </summary>
        public List<FeatureAccessRight> AvailableAccessRights { get; set; }

    }
}
