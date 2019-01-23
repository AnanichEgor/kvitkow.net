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
    public interface ISecurityService :IDisposable
    {
        #region General Administation
        /// <summary>
        /// Получение списка прав доступа
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessRight>> GetRights(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление прав доступа
        /// </summary>
        /// <param name="rights">Добавляемое право доступа</param>
        /// <returns></returns>
        Task<AddRightResponse> AddRights(AccessRight[] rights);

        /// <summary>
        /// Удаление прав доступа
        /// </summary>
        /// <param name="rightId">Идентификатор права доступа</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteRight(int rightId);

        /// <summary>
        /// Получение списка функций
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessFunction>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление функции
        /// </summary>
        /// <param name="function">Идентификатор функции</param>
        /// <returns></returns>
        Task<AddFunctionResponse> AddFunction(AccessFunction function);

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

        /// <summary>
        /// Получение списка фич
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Feature>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление фичи
        /// </summary>
        /// <param name="feature">Добавляемая фича</param>
        /// <returns></returns>
        Task<AddFeatureResponse> AddFeature(Feature feature);

        /// <summary>
        /// Удаление фичи
        /// </summary>
        /// <param name="featureId">Идентификатор фичи</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteFeature(int featureId);

        /// <summary>
        /// Изменение фичи
        /// </summary>
        /// <param name="featureId">Изменяемая фича</param>
        /// <param name="newRightId">Новый набор прав</param>
        /// <returns></returns>
        Task<ActionResponse> EditFeature(int featureId, int[] newRightId);

        /// <summary>
        /// Получение списка ролей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRoles(int itemsPerPage, int pageNumber, string mask = null);

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

        /// <summary>
        /// Получение списка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserRights> GetUserRights(string userId);

        /// <summary>
        /// Изменение прав доступа пользователя
        /// </summary>
        /// <param name="userRights">Набор прав доступа пользователя</param>
        /// <returns></returns>
        Task<ActionResponse> EditUserRights(UserRights userRights);

        /// <summary>
        /// Проверка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="rightName">Имя права доступа</param>
        /// <returns></returns>
        Task<AccessStatus> CheckAccess(string userId, string rightName);
        #endregion

        #region EventHandlers

        /// <summary>
        /// Предоставление прав доступа новому пользователю
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessRight>> SetDefaultRoleToNewUser();

        /// <summary>
        /// Предоставление прав доступа новому пользователю
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessRight>> UpdateUserInfo(string userId, 
            string userLogin, string firstName, string middleName, string lastName);
       
        #endregion
    }
}
