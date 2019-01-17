using System;

namespace StatisticOnline.Data.Models
{
    public class StatisticUserDb
    {
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Количество входов пользователя на сайт с момента регистрации
        /// </summary>
        public int CountInputs { get; set; }

        /// <summary>
        /// Количество сообщений пользователя на сайте с момента регистрации
        /// </summary>
        public int CountMessages { get; set; }

        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Время проведенное пользователем Online с момента последней авторизации.
        /// Используется для ограничения пребывания на сайте. Некоторые европейские нормы
        /// ограничивают это время 4мя часами, после который требуется 15минутный перерыв.
        /// </summary>
        public TimeSpan TimeOnSite { get; set; }

        /// <summary>
        /// Время проведенное пользователем Offline с момента последней авторизации
        /// Используется ограничения доступа к сайту/чату и т.д.
        /// </summary>
        public TimeSpan TimeOffSite { get; set; }
    }
}
