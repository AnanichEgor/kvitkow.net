using System;
using System.Collections.Generic;
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
        /// <param name="rightNames">Имена прав</param>
        /// <returns></returns>
        Task<AccessRightDb[]> AddRights(string[] rightNames);

        /// <summary>
        /// Удаление права доступа
        /// </summary>
        /// <param name="rightId">Идентификатор права доступа</param>
        /// <returns></returns>
        Task<bool> DeleteRight(int rightId);

        /// <summary>
        /// Получение списка функций
        /// </summary>
        /// <param name="itemsPerPage">Элементов на странице</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="mask">Маска поиска</param>
        /// <returns></returns>
        Task<IEnumerable<AccessFunctionDb>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление функции
        /// </summary>
        /// <param name="functionName">Имя функции</param>
        /// <param name="featureId">Идентификатор фичи</param>
        /// <returns></returns>
        Task<int> AddFunction(string functionName, int featureId);

        /// <summary>
        /// Удаление функции
        /// </summary>
        /// <param name="functionId">Идентификатор функции</param>
        /// <returns></returns>
        Task<bool> DeleteFunction(int functionId);

        /// <summary>
        /// Изменение функции
        /// </summary>
        /// <param name="functionId">Идентификатор функции</param>
        /// <param name="newRights">набор идентификаторов прав</param>
        /// <returns></returns>
        Task<bool> EditFunctionRights(int functionId, int[] newRights);

        /// <summary>
        /// Получение списка фич
        /// </summary>
        /// <param name="itemsPerPage">Элементов на странице</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="mask">Маска поиска</param>
        /// <returns></returns>
        Task<IEnumerable<FeatureDb>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление фичи
        /// </summary>
        /// <param name="featureName">Имя фичи</param>
        /// <returns></returns>
        Task<int> AddFeature(string featureName);

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
        Task<bool> EditFeatureRights(int featureId, int[] newRulesList);

        /// <summary>
        /// Получение списка ролей
        /// </summary>
        /// <param name="itemsPerPage">Элементов на странице</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="mask">Маска поиска</param>
        /// <returns></returns>
        Task<IEnumerable<RoleDb>> GetRoles(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление роли
        /// </summary>
        /// <param name="roleName">Имя роли</param>
        /// <returns></returns>
        Task<int> AddRole(string roleName);

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <returns></returns>
        Task<bool> DeleteRole(int roleId);

        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="roleId">Изменяемая роль</param>
        /// <param name="accessedRightsIds">Разрешенные права</param>
        /// <param name="deniedRightsIds">Запрещённые права</param>
        /// <returns></returns>
        Task<bool> EditRoleRights(int roleId, int[] accessedRightsIds, int[] deniedRightsIds);

        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="roleId">Изменяемая роль</param>
        /// <param name="functionIds">Набор новых правил</param>
        /// <returns></returns>
        Task<bool> EditRoleFunctions(int roleId, int[] functionIds);

        /// <summary>
        /// Получение списка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserRightsDb> GetUserRights(string userId);

        /// <summary>
        /// Изменение прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleIds">Набор ролей</param>
        /// <param name="functionIds">Набор функций</param>
        /// <param name="accessedRightsIds">Разрешенные права</param>
        /// <param name="deniedRightsIds">Запрещённые права</param>
        /// <returns></returns>
        Task<bool> EditUserRights(string userId, int[]roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<bool> DeleteUserRights(string userId);

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="userInfo">Информация пользователя</param>
        /// <returns></returns>
        Task<bool> AddUser(UserInfoDb userInfo);

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="userInfo">Информация пользователя</param>
        /// <returns></returns>
        Task<bool> UpdateUser(UserInfoDb userInfo);

        /// <summary>
        /// Проверка доступности прав
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="accessRightNames">Набор прав</param>
        /// <returns></returns>
        Task<Dictionary<string, bool>> CheckAccess(string userId, string[] accessRightNames);
    }
}
