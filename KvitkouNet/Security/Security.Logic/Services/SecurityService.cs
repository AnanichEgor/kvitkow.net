using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Security.Data;
using Security.Data.Exceptions;
using Security.Data.Models;
using Security.Logic.Helpers;
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

        public async Task<AccessRightResponse> GetRights(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new AccessRightResponse
                    {
                        Status = ActionStatus.Warning,
                        Message = "BadRequest"
                    };
                }

                return new AccessRightResponse
                {
                    AccessRights = _mapper.Map<AccessRight[]>( await
                    _securityContext.GetRights(itemsPerPage, pageNumber, mask?.Trim())),
                    Status = ActionStatus.Success
                };
            }
            catch (SecurityDbException e)
            {
                return new AccessRightResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessRightResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<AccessRightResponse> AddRights(AccessRight[] rights)
        {
            try
            {
                if (rights.Any(l=>l.Name?.Trim().Length > 100))
                {
                    return new AccessRightResponse
                    {
                        Message = "Name is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }

                return new AccessRightResponse
                {
                    AccessRights = _mapper.Map<IEnumerable<AccessRight>>(await _securityContext
                        .AddRights(rights.Select(l=>new AccessRightDb(){Name = l.Name}).ToArray())).ToArray(),
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new AccessRightResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessRightResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> DeleteRight(int rightId)
        {
            try
            {
                if (rightId == 0)
                {
                   return new ActionResponse
                    {
                        Message = "Nothing was deleted on id = 0",
                        Status = ActionStatus.Warning
                    };
                }
                await _securityContext.DeleteRight(rightId);
                
                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<AccessFunctionResponse> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new AccessFunctionResponse
                    {
                        Status = ActionStatus.Warning,
                        Message = "BadRequest"
                    };
                }

                return new AccessFunctionResponse
                {
                    Status = ActionStatus.Success,
                    AccessFunctions = _mapper.Map<AccessFunction[]>(await
                        _securityContext.GetFunctions(itemsPerPage, pageNumber, mask?.Trim()))
                }; 
            }
            catch (SecurityDbException e)
            {
                return new AccessFunctionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessFunctionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> AddFunction(AccessFunction function)
        {
            try
            {
                if (function.Name?.Trim().Length > 100)
                {
                    return new ActionResponse
                    {
                        Message = "Name is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }
                if (function.AccessRights != null && function.AccessRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }
                if (function.FeatureId == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Wrong FeatureId id",
                        Status = ActionStatus.Warning
                    };
                }

                var id = await _securityContext.AddFunction(new AccessFunctionDb
                {
                    Name = function.Name,
                    FeatureId = function.FeatureId
                });

                if (function.AccessRights != null && function.AccessRights.Any())
                {
                    await _securityContext.EditFunctionRights(id,
                        function.AccessRights.Select(l => l.Id).ToArray());
                }

                return new ActionResponse
                {
                    Id = id,
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> DeleteFunction(int functionId)
        {
            try
            {
                if (functionId == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Nothing was deleted on id = 0",
                        Status = ActionStatus.Warning
                    };
                }
                await _securityContext.DeleteFunction(functionId);

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> EditFunction(AccessFunction function)
        {
            try
            {
                if (function.Id == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Wrong id",
                        Status = ActionStatus.Warning
                    };
                }
                if (function.AccessRights.Any(l=>l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }

                await _securityContext.EditFunctionRights(function.Id,
                    function.AccessRights.Select(l => l.Id).ToArray());

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<FeatureResponse> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new FeatureResponse
                    {
                        Message = "BadRequest",
                        Status = ActionStatus.Warning
                    };
                }

                return new FeatureResponse
                {
                    Features = _mapper.Map<Feature[]>(
                        await _securityContext.GetFeatures(itemsPerPage, pageNumber, mask?.Trim())).ToArray(),
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new FeatureResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new FeatureResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> AddFeature(Feature feature)
        {
            try
            {
                if (feature.Name?.Trim().Length > 100)
                {
                    return new ActionResponse
                    {
                        Message = "Name is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }

                if (feature.AvailableAccessRights!= null && feature.AvailableAccessRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }

                var id = await _securityContext.AddFeature(new FeatureDb()
                {
                    Name = feature.Name
                });

                if(feature.AvailableAccessRights != null && feature.AvailableAccessRights.Any())
                {
                    await _securityContext.EditFunctionRights(id,feature.AvailableAccessRights.Select(l => l.Id).ToArray());
                }

                return new ActionResponse
                {
                    Id = id,
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> DeleteFeature(int featureId)
        {
            try
            {
                if (featureId == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Nothing was deleted on id = 0",
                        Status = ActionStatus.Warning
                    };
                }
                await _securityContext.DeleteFeature(featureId);

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> EditFeature(Feature feature)
        {
            try
            {
                if (feature.Id == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Wrong id",
                        Status = ActionStatus.Warning
                    };
                }
                if (feature.AvailableAccessRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }

                await _securityContext.EditFeatureRules(feature.Id,
                    feature.AvailableAccessRights.Select(l => l.Id).ToArray());

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<RoleResponse> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            try
            {
                if (itemsPerPage < 1 || pageNumber < 1 || int.MaxValue / itemsPerPage < pageNumber || mask?.Trim().Length > 100)
                {
                    return new RoleResponse
                    {
                        Status = ActionStatus.Warning,
                        Message = "BadRequest"
                    };
                }

                return new RoleResponse
                {
                    Roles = _mapper.Map<Role[]>(await
                        _securityContext.GetRoles(itemsPerPage, pageNumber, mask?.Trim())),
                    Status = ActionStatus.Success
                };
            }
            catch (SecurityDbException e)
            {
                return new RoleResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new RoleResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> AddRole(Role role)
        {
            try
            {
                if (role.Name?.Trim().Length > 100)
                {
                    return new ActionResponse
                    {
                        Message = "Name is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }
                if (role.AccessRights!=null && role.AccessRights.Any(l => l.Id == 0) || role.DeniedRights != null && role.DeniedRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }
                if (role.AccessFunctions != null && role.AccessFunctions.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Function id",
                        Status = ActionStatus.Warning
                    };
                }

                var id = await _securityContext.AddRole(new RoleDb
                {
                    Name = role.Name
                });

                if (role.AccessFunctions != null)
                {
                    await _securityContext.EditRoleFunctions(id, role.AccessFunctions.Select(l => l.Id).ToArray());
                }

                if (role.AccessFunctions != null || role.DeniedRights != null)
                {
                    await _securityContext.EditRoleRights(id,
                        role.AccessRights?.Select(l => l.Id).ToArray() ?? new int[0],
                        role.DeniedRights?.Select(l => l.Id).ToArray() ?? new int[0]);
                }

                return new ActionResponse
                {
                    Id = id,
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> DeleteRole(int roleId)
        {
            try
            {
                if (roleId == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Nothing was deleted on id = 0",
                        Status = ActionStatus.Warning
                    };
                }
                await _securityContext.DeleteRole(roleId);

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> EditRole(Role role)
        {
            try
            {
                if (role.Id == 0)
                {
                    return new ActionResponse
                    {
                        Message = "Wrong id",
                        Status = ActionStatus.Warning
                    };
                }
                if (role.AccessRights.Any(l => l.Id == 0) || role.DeniedRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }
                if (role.AccessFunctions.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Function id",
                        Status = ActionStatus.Warning
                    };
                }

                await _securityContext.EditRoleFunctions(role.Id, role.AccessFunctions.Select(l => l.Id).ToArray());
                await _securityContext.EditRoleRights(role.Id, role.AccessRights.Select(l => l.Id).ToArray(), role.DeniedRights.Select(l => l.Id).ToArray());

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<UserRightsResponse> GetUserRights(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return new UserRightsResponse
                    {
                        Status = ActionStatus.Warning,
                        Message = "BadRequest"
                    };
                }
                if (userId?.Trim().Length > 100)
                {
                    return new UserRightsResponse
                    {
                        Message = "UserId longer then 100",
                        Status = ActionStatus.Warning
                    };
                }

                return new UserRightsResponse
                {
                    UserRights = _mapper.Map<UserRights>(await
                        _securityContext.GetUserRights(userId)),
                    Status = ActionStatus.Success
                };
            }
            catch (SecurityDbException e)
            {
                return new UserRightsResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new UserRightsResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> AddNewUserRights(UserRights userRights)
        {
            try
            {
                if (string.IsNullOrEmpty(userRights.UserId))
                {
                    return new ActionResponse
                    {
                        Message = "UserId is empty",
                        Status = ActionStatus.Warning
                    };
                }
                if (userRights.UserId?.Trim().Length > 100)
                {
                    return new ActionResponse
                    {
                        Message = "UserId is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }

                if (userRights.UserLogin?.Trim().Length > 100)
                {
                    return new ActionResponse
                    {
                        Message = "UserLogin is longer then 100",
                        Status = ActionStatus.Warning
                    };
                }

                if (userRights.AccessRights != null && userRights.AccessRights.Any(l => l.Id == 0) ||
                    userRights.DeniedRights != null && userRights.DeniedRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }

                if (userRights.AccessFunctions != null && userRights.AccessFunctions.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Function id",
                        Status = ActionStatus.Warning
                    };
                }

                if (userRights.Roles != null && userRights.Roles.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Function id",
                        Status = ActionStatus.Warning
                    };
                }

                await _securityContext.AddNewUserRights(_mapper.Map<UserRightsDb>(userRights));

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };
            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<ActionResponse> EditUserRights(UserRights userRights)
        {
            try
            {
                if (string.IsNullOrEmpty(userRights.UserId))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong id",
                        Status = ActionStatus.Warning
                    };
                }
                if (userRights.AccessRights.Any(l => l.Id == 0) || userRights.DeniedRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }
                if (userRights.AccessFunctions.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Function id",
                        Status = ActionStatus.Warning
                    };
                }
                if (userRights.Roles.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Role id",
                        Status = ActionStatus.Warning
                    };
                }

                await _securityContext.EditUserRights(userRights.UserId,
                    userRights.Roles.Select(l => l.Id).ToArray(),
                    userRights.AccessFunctions.Select(l => l.Id).ToArray(),
                    userRights.AccessRights.Select(l => l.Id).ToArray(),
                    userRights.DeniedRights.Select(l => l.Id).ToArray());

                return new ActionResponse
                {
                    Status = ActionStatus.Success
                };

            }
            catch (SecurityDbException e)
            {
                return new ActionResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ActionResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<AccessStatus> CheckAccess(string userId, string rightName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<AccessRight>> SetDefaultRoleToNewUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<AccessRight>> UpdateUserInfo(string userId, string userLogin, string firstName, string middleName, string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}