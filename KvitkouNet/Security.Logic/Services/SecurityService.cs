using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Data.Context;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    public class SecurityService : ISecurityService
    {
        private SecurityContext _securityContext;

        public SecurityService(SecurityContext securityContext)
        {
            _securityContext = securityContext;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AccessRight>> GetRights()
        {
            throw new System.NotImplementedException();
        }

        public Task<AddRightResponse> AddRight(AccessRight right)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> DeleteRight(int rightId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<AccessFunction>> GetFunctions()
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

        public Task<IEnumerable<Feature>> GetFeatures()
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

        public Task<IEnumerable<Role>> GetRoles()
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
    }
}