using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Logic.Common.Models.Security
{
    /// <summary>
    /// Право доступа
    /// </summary>
    public class AccessRight
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя права доступа
        /// </summary>
        public string Name { get; set; }
    }
}
