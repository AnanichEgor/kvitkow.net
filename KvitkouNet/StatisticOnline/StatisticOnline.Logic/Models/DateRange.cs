
/// <summary>
/// Модель диапазона дат для запросов статистики
/// </summary>

using System;

namespace StatisticOnline.Logic.Models
{
    public class DateRange
    {
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
