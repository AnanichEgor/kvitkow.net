using System.Collections.Generic;
using FluentValidation.Results;
using TicketManagement.Logic.Models.Enums;

namespace TicketManagement.Logic.Models
{
    /// <summary>
    ///     Модель статуса ответа
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        ///     Успешность запроса
        /// </summary>
        public RequestStatus Status { get; set; } = RequestStatus.Success;

        /// <summary>
        ///     Доп. сообщение к статусу
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Сообщение ошибки
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        ///     Источник ошибки
        /// </summary>
        public string ExceptionSource { get; set; }

        /// <summary>
        ///     List ошибок валидации
        /// </summary>
        public List<ValidationFailure> ValidationFailures { get; set; }

        /// <summary>
        ///     Возвращаемые данные
        /// </summary>
        public object Data { get; set; }
    }
}