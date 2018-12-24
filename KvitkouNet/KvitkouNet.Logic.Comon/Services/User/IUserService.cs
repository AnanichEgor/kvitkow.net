using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.UserManagement;

namespace KvitkouNet.Logic.Common.Services.User
{
    public interface IUserService: IDisposable
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> Register(UserRegisterModel model);

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ForViewModel>> GetAll();

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<ForViewModel> GetByLogin(string login);

        /// <summary>
        /// Обновление пользователя по логину
        /// </summary>
        /// <param name="login"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        Task<ForUpdateModel> UpdateByLogin(string login, ForUpdateModel userModel);

        /// <summary>
        /// Удаление пользователя по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<string> DeleteByLogin(string login);
    }
}