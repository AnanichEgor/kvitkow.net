using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Security
{
    /// <summary>
    /// Функция доступа к фиче
    /// </summary>
    public class AccessFunction
    {
        /// <summary>
        /// Идентификатор функции
        /// </summary>
        public Guid Id { get; set; }

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
        public List<AccessRight> AccessRights { get; set; }
    }
}
