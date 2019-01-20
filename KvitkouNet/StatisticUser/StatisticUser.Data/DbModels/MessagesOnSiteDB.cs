using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticUser.Data.DbModels
{
    /// <summary>
    /// Хранит статистику по количеству сообщений
    /// зарегистрированных пользователей
    /// </summary>
    public class MessagesUsersOnSiteDB
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MessageCount { get; set; }
    }
}
