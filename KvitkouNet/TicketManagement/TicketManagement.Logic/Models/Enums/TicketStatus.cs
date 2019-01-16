﻿using System;

namespace TicketManagement.Logic.Models
{
    /// <summary>
    ///     Перечисление, описывающее статус билета
    /// </summary>
    
    public enum TicketStatus
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