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
    public class FunctionService : IFunctionService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<AccessFunction> _validator;

        public FunctionService(ISecurityData securityContext, IMapper mapper, IValidator<AccessFunction> validator)
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

        ~FunctionService()
        {
            Dispose(false);
        }

        #endregion
        
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
                var validationResult = await _validator.ValidateAsync(function);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
                }
                if (function.AccessRights != null && function.AccessRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
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
    }
}