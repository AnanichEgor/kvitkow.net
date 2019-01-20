using System;

namespace StatisticUser.Data.DbModels
{
    /// <summary>
    /// Статистика посещения ресурсов сайта
    /// TimeOnResource время определяется от последней активности
    /// из таблицы TimeOnSite
    /// </summary>
    public class OpenResourcesDb
    {
        public int Id { get; set; }
        public ResourcesUrlDB ResourceId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeOnResource { get; set; }
    }
}
