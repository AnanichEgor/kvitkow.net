using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticUser.Data.DbModels
{
    /// <summary>
    /// Время, проведенное пользователем на сайте.
    /// Методика определения времени:
    /// После авторизации пользователя на сайте сохраняем метку времени.
    /// Отслеживаем активность пользователя, определяем время и вычитаем из него
    /// время регистрации на сайте и суммируем со значение в поле "TimeOnline"
    /// Если пользователь провел время на последнем запрошенном ресурсе сайта
    /// не проевляя активность и закрыл браузер, то это время не учитывается.
    /// Новая авторизация пользователя создает новую запись в BD
    /// 
    /// </summary>
    public class TimeOnSite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DataTimeAuthorization { get; set; }
        public TimeSpan TimeOnline { get; set; }
    }
}
