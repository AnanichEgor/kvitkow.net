using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Data.DbModels.DbEnums
{
    /// <summary>
    ///     Перечисление, описывающее статус новости
    /// </summary>
    public enum NewsStatusDb
    {
        /// <summary>
        ///     Тип не установлен
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Куплен
        /// </summary>
        Purchased = 1,

        /// <summary>
        ///     Актуален
        /// </summary>
        Actual = 2,

        /// <summary>
        ///     Просрочен
        /// </summary>
        Expired = 3
    }
}
