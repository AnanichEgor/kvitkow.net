using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Security.Data;
using Security.Data.Exceptions;
using Security.Data.Models;
using Security.Logic.Helpers;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;
using Security.Logic.Services;

namespace Security.Logic.Implementations
{
    public class UserRightsService : IUserRightsService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<UserRights> _validator;

        public UserRightsService(ISecurityData securityContext, IMapper mapper, IValidator<UserRights> validator)
        {
            _securityContext = securityContext;
            _mapper = mapper;
            _validator = validator;
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

        ~UserRightsService()
        {
            Dispose(false);
        }

        #endregion
        
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
                var validationResult = await _validator.ValidateAsync(userRights);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
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

        public async Task<ActionResponse> DeleteUserRights(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return new ActionResponse
                    {
                        Message = "Nothing was deleted on empty id",
                        Status = ActionStatus.Warning
                    };
                }
                await _securityContext.DeleteUserRights(userId);

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