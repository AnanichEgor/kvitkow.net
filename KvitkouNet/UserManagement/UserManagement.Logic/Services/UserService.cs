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
            var model = await _unitOfWork.Users.GetByLoginAsync(login);
            return model != null ? (_mapper.Map<ForViewModel>(model)):(null);
        }

        public async Task<ForViewModel> Get(string id)
        {
            var model = await _unitOfWork.Users.GetAsync(id);
            return model != null ? (_mapper.Map<ForViewModel>(model)) : (null);
        }

        public async Task<string> Update(string id, ForUpdateModel userModel)
        {
            var findUser = _unitOfWork.Users.FindAsync(x => x.Id == id).Result.FirstOrDefault();
            if (findUser == null) return "Not Found";
            await _unitOfWork.Users.UpdateAsync(_mapper.Map<UserDB>(userModel), id);
            return "Ok";
        }

        public async Task<string> Delete(string id)
        {
            var findUser = _unitOfWork.Users.FindAsync(x => x.Id == id).Result.FirstOrDefault();
            if (findUser == null) return "Not Found";
            await _unitOfWork.Users.DeleteAsync(findUser);
            return "Ok";
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
