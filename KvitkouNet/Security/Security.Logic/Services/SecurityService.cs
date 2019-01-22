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
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return Task.FromResult(new AccessRight[0].AsEnumerable());
                }

                return Task.FromResult(_mapper.Map<AccessRight[]>(
                    _securityContext.GetRights(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<AddRightResponse> AddRight(AccessRight right)
        {
            try
            {
                if (right.Name?.Trim().Length > 100)
                {
                    return Task.FromResult(new AddRightResponse() { Message = "Name is longer then 100", Status = ActionStatus.Error });
                }
                if (_securityContext.GetRights(int.MaxValue, 1, right.Name).Any(l => l.Name.Equals(right.Name)))
                {
                    return Task.FromResult(new AddRightResponse() { Message = "Name already exists", Status = ActionStatus.Error });
                }

                return Task.FromResult(new AddRightResponse()
                {
                    Id = _securityContext.AddRight(new AccessRightDb() {Name = right.Name}),
                    Status = ActionStatus.Success
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult(new AddRightResponse()
                {
                    Message = "Unknown error",
                    Status = ActionStatus.Error
                });
            }
        }

        public Task<ActionResponse> DeleteRight(int rightId)
        {
            try
            {
                if (rightId == 0)
                {
                    return Task.FromResult(new ActionResponse()
                    {
                        Message = "Nothing was deleted on id = 0",
                        Status = ActionStatus.Warning
                    });
                }
                _securityContext.DeleteRight(rightId);
                
                return Task.FromResult(new ActionResponse()
                {
                    Status = ActionStatus.Success
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult(new ActionResponse()
                {
                    Message = "Unknown error",
                    Status = ActionStatus.Error
                });
            }
        }

        public Task<IEnumerable<AccessFunction>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return Task.FromResult(new AccessFunction[0].AsEnumerable());
                }

                return Task.FromResult(_mapper.Map<AccessFunction[]>(
                    _securityContext.GetFunctions(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<AddFunctionResponse> AddFunction(AccessFunction function)
        {
            try
            {
                if (function.Name?.Trim().Length > 100)
                {
                    return Task.FromResult(new AddFunctionResponse() { Message = "Name is longer then 100", Status = ActionStatus.Error });
                }
                if (_securityContext.GetFunctions(int.MaxValue, 1, function.Name).Any(l => l.Name.Equals(function.Name)))
                {
                    return Task.FromResult(new AddFunctionResponse() { Message = "Name already exists", Status = ActionStatus.Error });
                }

                return Task.FromResult(new AddFunctionResponse()
                {
                    Id = _securityContext.AddFunction(new AccessFunctionDb()
                    {
                        Name = function.Name,
                        AccessRights = _mapper.Map<List<AccessRightDb>>(function.AccessRights)
                    }),
                    Status = ActionStatus.Success
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult(new AddFunctionResponse()
                {
                    Message = "Unknown error",
                    Status = ActionStatus.Error
                });
            }
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
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return Task.FromResult(new Feature[0].AsEnumerable());
                }

                return Task.FromResult(_mapper.Map<Feature[]>(
                    _securityContext.GetFeatures(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return Task.FromResult(new Role[0].AsEnumerable());
                }

                return Task.FromResult(_mapper.Map<Role[]>(
                    _securityContext.GetRoles(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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