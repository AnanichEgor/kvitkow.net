using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Security.Data.Models;

namespace Security.Data
{
    public interface ISecurityData : IDisposable
    {
        /// <summary>
        /// Получение списка прав доступа
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessRightDb>> GetRights(int itemsPerPage, int pageNumber, string mask);

        /// <summary>
        /// Добавление права доступа
        /// </summary>
        /// <param name="rights">Добавляемые право доступа</param>
        /// <returns></returns>
        Task<AccessRightDb[]> AddRights(AccessRightDb[] rights);

        /// <summary>
        /// Удаление права доступа
        /// </summary>
        /// <param name="rightId">Идентификатор права доступа</param>
        /// <returns></returns>
        Task<bool> DeleteRight(int rightId);

        /// <summary>
        /// Получение списка функций
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessFunctionDb>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление функции
        /// </summary>
        /// <param name="function">Идентификатор функции</param>
        /// <returns></returns>
        Task<int> AddFunction(AccessFunctionDb function);

        /// <summary>
        /// Удаление функции
        /// </summary>
        /// <param name="functionId">Идентификатор функции</param>
        /// <returns></returns>
        Task<bool> DeleteFunction(int functionId);

        /// <summary>
        /// Изменение функции
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="newRights"></param>
        /// <returns></returns>
        Task<bool> EditFunctionRights(int functionId, int[] newRights);

        /// <summary>
        /// Получение списка фич
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FeatureDb>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление фичи
        /// </summary>
        /// <param name="feature">Добавляемая фича</param>
        /// <returns></returns>
        Task<int> AddFeature(FeatureDb feature);

        /// <summary>
        /// Удаление фичи
        /// </summary>
        /// <param name="featureId">Идентификатор фичи</param>
        /// <returns></returns>
        Task<bool> DeleteFeature(int featureId);

        /// <summary>
        /// Изменение фичи
        /// </summary>
        /// <param name="featureId">Изменяемая фича</param>
        /// <param name="newRulesList">Новый набор правил</param>
        /// <returns></returns>
        Task<bool> EditFeatureRules(int featureId, int[] newRulesList);

        /// <summary>
        /// Получение списка ролей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoleDb>> GetRoles(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление роли
        /// </summary>
        /// <param name="role">Добавляемая роль</param>
        /// <returns></returns>
        Task<int> AddRole(RoleDb role);

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <returns></returns>
        Task<bool> DeleteRole(int roleId);

        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="role">Изменяемая роль</param>
        /// <returns></returns>
        Task<bool> EditRoleRights(int roleId, int[] accessedRightsIds, int[] deniedRightsIds);

        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="role">Изменяемая роль</param>
        /// <returns></returns>
        Task<bool> EditRoleFunctions(int roleId, int[] functionIds);

        /// <summary>
        /// Получение списка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserRightsDb> GetUserRights(string userId);

        /// <summary>
        /// Получение списка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<bool> AddNewUserRights(UserRightsDb userRights);

        /// <summary>
        /// Изменение прав доступа пользователя
        /// </summary>
        /// <param name="userRights">Набор прав доступа пользователя</param>
        /// <returns></returns>
        Task<bool> EditUserRights(string userId, int[]roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds);
    }
}
