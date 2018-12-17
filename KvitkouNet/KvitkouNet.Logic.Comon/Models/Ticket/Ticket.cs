using System;
using KvitkouNet.Logic.Common.Models.Enums;

namespace KvitkouNet.Logic.Common.Models.Ticket
{
    /// <summary>
    ///     Класс описания доменной модели билета
    /// </summary>
    public class Ticket
    {
        /// <summary>
        ///     Платный/бесплатный билет
        /// </summary>
        public bool Free { get; set; }

        /// <summary>
        ///     Название билета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Id билета
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        ///     Страна проведения мероприятия
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Город проведения мероприятия
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Дата проведения мероприятия
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Цена билета
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Дополнительная информация билета
        /// </summary>
        public string AdditionalData { get; set; }

        /// <summary>
        ///     Телефон продавца
        /// </summary>
        public string SellerPhone { get; set; }

        /// <summary>
        ///     Адрес продавца
        /// </summary>
        public string SellerAdress { get; set; }

        /// <summary>
        ///     Платежная система
        /// </summary>
        public string PaymentSystems { get; set; }

        /// <summary>
        ///     Время актуальности билета
        /// </summary>
        public string TimeActual { get; set; }

        /// <summary>
        ///     Тип мероприятия
        /// </summary>
        public TypeEventTicket TypeEvent { get; set; }

        /// <summary>
        ///     Ссылка на мероприятие
        /// </summary>
        public string EventLink { get; set; }
    }
}