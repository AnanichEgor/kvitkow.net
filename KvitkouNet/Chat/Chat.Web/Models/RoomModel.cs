using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Web.Models
{
    public class RoomModel
    {
        /// <summary>
        /// номер комнаты
        /// </summary>
        public string Id;

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модификатор доступа комнаты
        /// </summary>
        public bool IsPrivat;
    }
}
