﻿using System;
using System.Collections.Generic;
using System.Text;
using Logging.Data.Enums;
using Logging.Logic.Models.Filters.Abstraction;

namespace Logging.Logic.Models.Filters
{
    public class DealLogFilter : BaseLogFilter
    {
        /// <summary>
        /// Пользователь-владелец, разместивший билет
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Покупатель/получатель билета
        /// </summary>
        public string RecieverId { get; set; }

        /// <summary>
        /// Начало диапазона цен
        /// </summary>
        public double MinPrice { get; set; }

        /// <summary>
        /// Конец диапазона цен
        /// </summary>
        public double MaxPrice { get; set; }

        /// <summary>
        /// Тип сделки
        /// </summary>
        public DealType Type { get; set; }
    }
}
