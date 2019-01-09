using System;

namespace TicketManagement.Logic.Models
{
    /// <summary>
    ///     Перечисление, описывающее статус билета
    /// </summary>
    [Flags]
    public enum TicketStatus
    {
        /// <summary>
        ///     Тип не установлен
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Куплен
        /// </summary>
        Purchased = 1 << 0,

        /// <summary>
        ///     Актуален
        /// </summary>
        Actual = 1 << 1,

        /// <summary>
        ///     Просрочен
        /// </summary>
        Expired = 1 << 2
    }
}