using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Security.Data;
using Security.Data.Models;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    public class SecurityService : ISecurityService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;

        public SecurityService(ISecurityData securityContext, IMapper mapper)
        {
            _securityContext = securityContext;
            _mapper = mapper;
        }

        #region DisposeImp
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            _securityContext.Dispose();
        }

        ~SecurityService()
        {
            Dispose(false);
        }

        #endregion

        public Task<IEnumerable<AccessRight>> GetRights(int itemsPerPage, int pageNumber, string mask = null)
        {
            if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber)
            {
                return Task.FromResult(new AccessRight[0].AsEnumerable());
            }

            return Task.FromResult(_mapper.Map<AccessRight[]>(
                _securityContext.GetRights(itemsPerPage, pageNumber, mask)).AsEnumerable());
        }

        public Task<AddRightResponse> AddRight(AccessRight right)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> DeleteRight(int rightId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AccessFunction>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<AddFunctionResponse> AddFunction(AccessFunction function)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> DeleteFunction(int functionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> EditFunction(AccessFunction function)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Feature>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<AddFeatureResponse> AddFeature(Feature feature)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> DeleteFeature(int featureId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> EditFeature(Feature feature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> AddRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> DeleteRole(int roleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> EditRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRights> GetUserRights(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> EditUserRights(UserRights userRights)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccessStatus> CheckAccess(string userId, string rightName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AccessRight>> SetDefaultRoleToNewUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AccessRight>> UpdateUserInfo(string userId, string userLogin, string firstName, string middleName, string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}