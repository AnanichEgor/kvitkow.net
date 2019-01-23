using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Security.Data;
using Security.Data.Exceptions;
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

        public async Task<IEnumerable<AccessRight>> GetRights(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new AccessRight[0].AsEnumerable();
                }

                return _mapper.Map<AccessRight[]>( await 
                    _securityContext.GetRights(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessRight[0];
            }
        }

        public async Task<AddRightResponse> AddRights(AccessRight[] rights)
        {
            try
            {
                if (rights.Any(l=>l.Name?.Trim().Length > 100))
                {
                    return new AddRightResponse() { Message = "Name is longer then 100", Status = ActionStatus.Error };
                }

                return new AddRightResponse()
                {
                    AccessRights = _mapper.Map<IEnumerable<AccessRight>>(await _securityContext
                        .AddRights(rights.Select(l=>new AccessRightDb(){Name = l.Name}).ToArray())).ToArray(),
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                Console.WriteLine(e);
                return new AddRightResponse()
                {
                    Message = e.Message,
                    Status = ActionStatus.Error
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AddRightResponse()
                {
                    Message = "Unknown error",
                    Status = ActionStatus.Error
                };
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

        public async Task<IEnumerable<AccessFunction>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new AccessFunction[0].AsEnumerable();
                }

                return _mapper.Map<AccessFunction[]>(await 
                    _securityContext.GetFunctions(itemsPerPage, pageNumber, mask?.Trim()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessFunction[0];
            }
        }

        public async Task<AddFunctionResponse> AddFunction(AccessFunction function)
        {
            try
            {
                if (function.Name?.Trim().Length > 100)
                {
                    return new AddFunctionResponse() { Message = "Name is longer then 100", Status = ActionStatus.Error };
                }

                return new AddFunctionResponse()
                {
                    Id = await _securityContext.AddFunction(new AccessFunctionDb()
                    {
                        Name = function.Name,
                        AccessRights = _mapper.Map<List<AccessRightDb>>(function.AccessRights)
                    }),
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                Console.WriteLine(e);
                return new AddFunctionResponse()
                {
                    Message = e.Message,
                    Status = ActionStatus.Error
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AddFunctionResponse()
                {
                    Message = "Unknown error",
                    Status = ActionStatus.Error
                };
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

        public async Task<IEnumerable<Feature>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new Feature[0].AsEnumerable();
                }

                return _mapper.Map<Feature[]>(
                    await _securityContext.GetFeatures(itemsPerPage, pageNumber, mask?.Trim())).AsEnumerable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Feature [0];
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

        public Task<ActionResponse> EditFeature(int featureId, int[] rightId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new Role[0].AsEnumerable();
                }

                return _mapper.Map<Role[]>( await 
                    _securityContext.GetRoles(itemsPerPage, pageNumber, mask?.Trim()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Role[0];
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