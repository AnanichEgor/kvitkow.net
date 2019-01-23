using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Logic.Models;

namespace UserManagement.Logic.Services
{
    class UserService : IUserService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public UserService(IMapper mapper, IValidator validator)
        {
            _mapper = mapper;
            _validator = validator;
        }

        public Task<string> AddGroup(GroupModel userGroupModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ForViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupModel>> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ForViewModel>> GetAllUsersInGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ForViewModel> GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(UserRegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ForUpdateModel> UpdateByLogin(string login, ForUpdateModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> UpdateGroupById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
