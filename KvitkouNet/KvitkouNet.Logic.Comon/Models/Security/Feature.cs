using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Security
{
    /// <summary>
    /// Фича
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Идентификатор фичи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя фичи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список прав предоставляемых фичей
        /// </summary>
        public List<AccessRight> AvailableAccessRights { get; set; }
    }
}
