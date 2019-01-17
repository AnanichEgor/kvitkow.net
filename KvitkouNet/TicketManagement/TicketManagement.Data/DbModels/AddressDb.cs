﻿using System.Collections.Generic;

namespace TicketManagement.Data.DbModels
{
    public class AddressDb
    {
        /// <summary>
        ///     Id адреса
        /// </summary>
        public string AddressDbId { get; set; }

        /// <summary>
        ///     Страна проживания
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     Номер дома, корпус
        /// </summary>
        public string House { get; set; }

        /// <summary>
        ///     Номер квартиры
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        ///     Список билетов по этому адресу
        /// </summary>
        public List<TicketDb> Tickets { get; set; }
    }
}