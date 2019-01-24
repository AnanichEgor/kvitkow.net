using System;
using System.Threading.Tasks;
using Security.Logic.Models;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Security
    /// </summary>
    public interface IRoleService : IDisposable
    {
        /// <summary>
        /// Получение списка ролей
        /// </summary>
        /// <returns></returns>
        Task<RoleResponse> GetRoles(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление роли
        /// </summary>
        /// <param name="role">Добавляемая роль</param>
        /// <returns></returns>
        Task<ActionResponse> AddRole(Role role);

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteRole(int roleId);

        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="role">Изменяемая роль</param>
        /// <returns></returns>
        Task<ActionResponse> EditRole(Role role);
    }
}
