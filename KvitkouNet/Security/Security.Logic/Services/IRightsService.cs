using System;
using System.Threading.Tasks;
using Security.Logic.Models;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Security
    /// </summary>
    public interface IRightsService : IDisposable
    {
        /// <summary>
        /// Получение списка прав доступа
        /// </summary>
        /// <returns></returns>
        Task<AccessRightResponse> GetRights(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление прав доступа
        /// </summary>
        /// <param name="rights">Добавляемое право доступа</param>
        /// <returns></returns>
        Task<AccessRightResponse> AddRights(AccessRight[] rights);

        /// <summary>
        /// Удаление прав доступа
        /// </summary>
        /// <param name="rightId">Идентификатор права доступа</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteRight(int rightId);
    }
}
