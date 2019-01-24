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
    public class RightsService : IRightsService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<AccessRight> _validator;

        public RightsService(ISecurityData securityContext, IMapper mapper, IValidator<AccessRight> validator)
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

        ~RightsService()
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
                var validationFaults = rights.Select(l => _validator.Validate(l)).Where(l => !l.IsValid);
                if (validationFaults.Any())
                {
                    var response = ValidationResponseHelper.GetResponse(validationFaults);
                    return new AccessRightResponse
                    {
                        Status = response.Status,
                        Message = response.Message
                    };
                }
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
                    AccessRights = _mapper.Map<IEnumerable<AccessRight>>(
                        await _securityContext
                            .AddRights(rights.Select(l => new AccessRightDb {Name = l.Name}).ToArray())).ToArray(),
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
    }
}