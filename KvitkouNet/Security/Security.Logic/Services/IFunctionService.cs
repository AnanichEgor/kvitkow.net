using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Security
    /// </summary>
    public interface IFunctionService : IDisposable
    {
        /// <summary>
        /// Получение списка функций
        /// </summary>
        /// <returns></returns>
        Task<AccessFunctionResponse> GetFunctions(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление функции
        /// </summary>
        /// <param name="function">Идентификатор функции</param>
        /// <returns></returns>
        Task<ActionResponse> AddFunction(AccessFunction function);

        /// <summary>
        /// Удаление функции
        /// </summary>
        /// <param name="functionId">Идентификатор функции</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteFunction(int functionId);

        /// <summary>
        /// Изменение функции
        /// </summary>
        /// <param name="function">Изменяемая функция</param>
        /// <returns></returns>
        Task<ActionResponse> EditFunction(AccessFunction function);
    }
}