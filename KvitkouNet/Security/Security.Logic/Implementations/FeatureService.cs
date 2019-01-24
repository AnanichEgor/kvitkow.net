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
    public class FeatureService : IFeatureService
    {
        private ISecurityData _securityContext;
        private IMapper _mapper;
        private IValidator<Feature> _validator;

        public FeatureService(ISecurityData securityContext, IMapper mapper, IValidator<Feature> validator)
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

        ~FeatureService()
        {
            Dispose(false);
        }

        #endregion

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
                var validationResult = await _validator.ValidateAsync(feature);
                if (!validationResult.IsValid)
                {
                    return ValidationResponseHelper.GetResponse(validationResult);
                }

                if (feature.AvailableAccessRights!= null && feature.AvailableAccessRights.Any(l => l.Id == 0))
                {
                    return new ActionResponse
                    {
                        Message = "Wrong Access Right id",
                        Status = ActionStatus.Warning
                    };
                }

                var id = await _securityContext.AddFeature(new FeatureDb
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
    }
}