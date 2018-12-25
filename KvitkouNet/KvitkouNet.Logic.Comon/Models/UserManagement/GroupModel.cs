using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Logic.Common.Models.UserManagement
{
    public class GroupModel
    {
        /// <summary>
        /// Уникальный номер группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание назначения группы
        /// </summary>
        public string Description { get; set; }
    }
}