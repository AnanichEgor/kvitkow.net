using System;
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
    public class RoleService : IRoleService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<Role> _validator;

        public RoleService(ISecurityData securityContext, IMapper mapper, IValidator<Role> validator)
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

        ~RoleService()
        {
            Dispose(false);
        }

        #endregion

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
                var validationResult = await _validator.ValidateAsync(role);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
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
    }
}