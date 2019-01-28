using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.Services
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
        IEnumerable<ForViewModel> GetAll();

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ForViewModel>> GetAllAsync();

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

        /// <summary>
        /// Добавление группы
        /// </summary>
        /// <param name="userGroupModel"></param>
        /// <returns></returns>
        Task<string> AddGroup(GroupModel userGroupModel);

        /// <summary>
        /// Получение всех групп
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GroupModel>> GetAllGroups();

        /// <summary>
        /// Получение группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GroupModel> GetGroupById(int id);

        /// <summary>
        /// Обновление группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GroupModel> UpdateGroupById(int id);

        /// <summary>
        /// Удаление группы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteGroupById(int id);

        /// <summary>
        /// Получение всех пользователей состоящих в группе с id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<ForViewModel>> GetAllUsersInGroupById(int id);
    }
}