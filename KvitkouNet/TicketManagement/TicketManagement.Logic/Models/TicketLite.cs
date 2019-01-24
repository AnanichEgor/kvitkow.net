﻿using System;
using TicketManagement.Logic.Models.Enums;

namespace TicketManagement.Logic.Models
{
    /// <summary>
    ///     Класс описывающий минимальный набор необходимых свойств для вывода на странице
    /// </summary>
    public class TicketLite
    {
        /// <summary>
        ///     Пользователь разместивший билет
        /// </summary>
        public UserInfo User { get; set; }

        /// <summary>
        ///     Платный/бесплатный билет
        /// </summary>
        public bool Free { get; set; }

        /// <summary>
        ///     Название билета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        ///     Статус билета
        /// </summary>
        public TicketStatus Status { get; set; }

        /// <summary>
        ///     Дата создания билета
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}