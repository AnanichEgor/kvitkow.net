﻿using System.Collections.Generic;

namespace TicketManagement.Data.DbModels
{
    /// <summary>
    ///     Класс для передачи списка тикетов "пачками"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T>
    {
        /// <summary>
        ///     Текущая страница (приходит с фронта)
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        ///     Количество записей на странице (приходит с фронта)
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Количество страниц (вычисляется в репозитории)
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Список тикетов
        /// </summary>
        public List<T> Tickets { get; set; }

        public Page()
        {
            Tickets = new List<T>();
        }

        public Page(IEnumerable<T> records)
        {
            Tickets = new List<T>(records);
        }
    }
}