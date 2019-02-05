using System;
using System.Collections.Generic;
using FluentValidation.Results;
using TicketManagement.Logic.Models.Enums;

namespace TicketManagement.Logic.Models
{
    /// <summary>
    /// Модель статуса ответа
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Успешность запроса
        /// </summary>
        public RequestStatus Status { get; set; } = RequestStatus.Success;
        /// <summary>
        /// Доп. сообщение к статусу
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Критическая ошибка
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// List ошибок валидации
        /// </summary>
        public List<ValidationFailure> ValidationFailures { get; set; }
    }
}