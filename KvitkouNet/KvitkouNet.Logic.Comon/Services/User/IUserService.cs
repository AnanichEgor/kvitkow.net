using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.UserManagement;

namespace KvitkouNet.Logic.Common.Services.User
{
    public interface IUserService: IDisposable
    {
        Task<string> Register(UserRegisterModel model);
        Task<IEnumerable<ForViewModel>> GetAll();


    }
}