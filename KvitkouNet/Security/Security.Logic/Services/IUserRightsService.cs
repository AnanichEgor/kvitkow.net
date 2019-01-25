using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Requests;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Security
    /// </summary>
    public interface IUserRightsService : IDisposable
    {
        /// <summary>
        /// Получение списка прав доступа пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<UserRightsResponse> GetUserRights(string userId);

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="userRights"></param>
        /// <returns></returns>
        Task<ActionResponse> AddNewUserRights(UserRights userRights);

        /// <summary>
        /// Изменение прав доступа пользователя
        /// </summary>
        /// <param name="userRights">Набор прав доступа пользователя</param>
        /// <returns></returns>
        Task<ActionResponse> EditUserRights(UserRights userRights);

        /// <summary>
        /// Удаление пользователя из системы
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ActionResponse> DeleteUserRights(string userId);

        /// <summary>
        /// Проверка прав доступа пользователя
        /// </summary>
        /// <param name="accessRequest">Запрос наличия доступа</param>
        /// <returns></returns>
        Task<AccessResponse> CheckAccess(AccessRequest accessRequest);

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
