using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = _validator.Validate(model);
            if (!result.IsValid) return result.Errors.First().ToString();
            var findLogin = _unitOfWork.Accounts.FindAsync(x => x.Login == model.Username).Result.Count();
            if (findLogin!=0)
            {
                return "Sorry, this username allready exist!";
            }
            var res = await _unitOfWork.Users.AddAsync(_mapper.Map<UserDB>(model));
            return "Ok";
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

        public async Task<ForViewModel> GetByLogin(string login)
        {
            var model = await _unitOfWork.Users.GetAsync(login);
            return model != null ? (_mapper.Map<ForViewModel>(model)):(null);
        }

        public Task<ForUpdateModel> UpdateByLogin(string login, ForUpdateModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteByLogin(string login)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<GroupModel>> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Task<string> AddGroup(GroupModel userGroupModel)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupModel> UpdateGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ForViewModel>> GetAllUsersInGroupById(int id)
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
