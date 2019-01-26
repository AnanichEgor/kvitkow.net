﻿using System;
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
using Security.Logic.Models.Requests;
using Security.Logic.Models.Responses;
using Security.Logic.Services;

namespace Security.Logic.Implementations
{
    public class UserRightsService : IUserRightsService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<UserRights> _userRightsValidator;
        private IValidator<CheckAccessRequest> _accessRequestValidator;

        public UserRightsService(ISecurityData securityContext, 
            IMapper mapper, 
            IValidator<UserRights> userRightsValidator, 
            IValidator<CheckAccessRequest> accessRequestValidator)
        {
            _securityContext = securityContext;
            _mapper = mapper;
            _userRightsValidator = userRightsValidator;
            _accessRequestValidator = accessRequestValidator;
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

        public async Task<ActionResponse> AddNewUser(UserInfo userInfo)
        {
            try
            {
                var validationResult = await _userRightsValidator.ValidateAsync(userInfo);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
                }

                
                await _securityContext.AddUser(_mapper.Map<UserInfoDb>(userInfo));

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

        public async Task<ActionResponse> EditUserRights(string userId, int[] roleIds, int[] functionIds,
            int[] accessedRightsIds, int[] deniedRightsIds)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong id",
                        Status = ActionStatus.Warning
                    };
                }

                if (accessedRightsIds.Intersect(deniedRightsIds).Any())
                {
                    return new ActionResponse
                    {
                        Status = ActionStatus.Warning,
                        Message = "Accessed and denied must not have same Rights"
                    };
                }

                roleIds = roleIds ?? new int[0];
                functionIds = functionIds ?? new int[0];
                accessedRightsIds = accessedRightsIds ?? new int[0];
                deniedRightsIds = deniedRightsIds ?? new int[0];

                await _securityContext.EditUserRights(userId,roleIds,
                    functionIds,
                    accessedRightsIds,
                    deniedRightsIds);

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

        public async Task<AccessResponse> CheckAccess(CheckAccessRequest accessRequest)
        {
            try
            {
                var validationResult = await _accessRequestValidator.ValidateAsync(accessRequest);
                if (!validationResult.IsValid)
                {
                    var response = ValidationResponseHelper.GetResponse(validationResult);
                    return new AccessResponse
                    {
                        Status = response.Status,
                        Message = response.Message
                    };
                }
                

                var result = await _securityContext.CheckAccess(accessRequest.UserId, accessRequest.AccessRightNames);

                return new AccessResponse
                {
                    Status = ActionStatus.Success,
                    AccessRightNames = result
                };

            }
            catch (SecurityDbException e)
            {
                return new AccessResponse
                {
                    Status = ActionStatus.Warning,
                    Message = PrettyExceptionHelper.GetMessage(e)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new AccessResponse
                {
                    Status = ActionStatus.Error,
                    Message = "Something went wrong!"
                };
            }
        }

        public async Task<IEnumerable<AccessRight>> SetDefaultRoleToNewUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResponse> UpdateUserInfo(UserInfo userInfo)
        {
            try
            {
                var validationResult = await _userRightsValidator.ValidateAsync(userInfo);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
                }


                await _securityContext.UpdateUser(_mapper.Map<UserInfoDb>(userInfo));

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
    }
}