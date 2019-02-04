using System;

namespace TicketManagement.Logic.Models.Enums
{
    /// <summary>
    ///     Перечисление описывающее успешность запроса
    /// </summary>
    [Flags]
    public enum RequestStatus
    {
        /// <summary>
        ///     Успех
        /// </summary>
        Success = 0,

        /// <summary>
        ///     Невалидная модель
        /// </summary>
        InvalidModel = 1 << 0,

        /// <summary>
        ///     Ошибка доступа
        /// </summary>
        AcceesError = 1 << 1,

        /// <summary>
        ///     Ошибка
        /// </summary>
        Error = 1 << 2,

        /// <summary>
        ///     Неавторизованный пользователь
        /// </summary>
        Unauthorized = 1 << 3,

        /// <summary>
        ///     Пользователь имеет отрицательный рейтинг
        /// </summary>
        BadUserRating = 1 << 4,

        /// <summary>
        ///     Успех c ошибками
        /// </summary>
        SuccessWithErrors = 1 << 5

    }
}