using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Data.DbModels;
using UserManagement.Data.Repositories;
using UserManagement.Logic.Models;


namespace UserManagement.Logic.Services
{
    class UserService : IUserService
    {
        
        private readonly IMapper _mapper;
        private readonly IValidator<UserRegisterModel> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IValidator<UserRegisterModel> validator, IUnitOfWork unitOfWork)// ) 
        {
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Register(UserRegisterModel model)
        {
            _validator.Validate(model);
            var res = await _unitOfWork.Accounts.AddAsync(_mapper.Map<AccountDB>(model));
            _unitOfWork.SaveChanges();
            return res.Login;
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

        public async Task<IEnumerable<ForViewModel>> GetAllAsync()
        {
            var res = await _unitOfWork.Users.GetAllAsync();
            var temp = _mapper.Map<IEnumerable<ForViewModel>>(res);
            return temp;
        }
        public IEnumerable<ForViewModel> GetAll()
        {
            var res = _unitOfWork.Users.GetAll();
            var temp = _mapper.Map<IEnumerable<ForViewModel>>(res);
            return temp;
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

        

        public Task<ForUpdateModel> UpdateByLogin(string login, ForUpdateModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> UpdateGroupById(int id)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
