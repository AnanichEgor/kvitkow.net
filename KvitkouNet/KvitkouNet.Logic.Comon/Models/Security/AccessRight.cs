using System;

namespace KvitkouNet.Logic.Common.Models.Security
{
    /// <summary>
    /// Право доступа
    /// </summary>
    public class AccessRight
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя права доступа
        /// </summary>
        public string Name { get; set; }
    }
}
