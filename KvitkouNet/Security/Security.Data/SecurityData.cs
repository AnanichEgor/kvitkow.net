using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security.Data.Context;
using Security.Data.ContextModels;
using Security.Data.Exceptions;
using Security.Data.Models;

namespace Security.Data
{
    public class SecurityData : ISecurityData
    {
        private SecurityContext _context;
        private IMapper _mapper;

        public SecurityData(SecurityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<AccessRightDb>> GetRights(int itemsPerPage, int pageNumber, string mask)
        {
            var rights = await _context.AccessRights
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync();
            return _mapper.Map<IEnumerable<AccessRightDb>>(rights);
        }

        public async Task<AccessRightDb[]> AddRights(string[] accessRights)
        {
            var existed = await _context.AccessRights
                .Where(l => accessRights.Any(k => k.Equals(l.Name)))
                .ToArrayAsync();
            if (existed.Any())
            {
                throw new SecurityDbException("Names already exist", ExceptionType.NameExists, EntityType.Right, existed.Select(l => l.Name).ToArray());
            }
            var rights = _mapper.Map<AccessRight[]>(accessRights);
            await _context.AccessRights.AddRangeAsync(rights);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccessRightDb[]>(rights);
        }

        public async Task<bool> DeleteRight(int rightId)
        {
            var right = await _context.AccessRights.SingleOrDefaultAsync(l => l.Id == rightId);
            if (right == null)
            {
                throw new SecurityDbException("AccessRight was not found", ExceptionType.NotFound, EntityType.Right, new []{ rightId.ToString() });
            }

            _context.AccessRights.Remove(right);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AccessFunctionDb>> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            return _mapper.Map<IEnumerable<AccessFunctionDb>>(await _context.AccessFunctions.Include(l=>l.AccessFunctionAccessRights).ThenInclude(l=>l.AccessFunction)
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync());
        }

        public async Task<int> AddFunction(string functionName, int featureId)
        {
            if (await _context.AccessFunctions.AnyAsync(l => functionName.Equals(l.Name)))
            {
                throw new SecurityDbException(
                    "Names already exist", ExceptionType.NameExists, EntityType.Function, new []{ functionName });
            }

            CheckFeaturesExist(new[] { featureId });

            var functionMapped = _mapper.Map<AccessFunction>(functionName);
            await _context.AccessFunctions.AddAsync(functionMapped);
            await _context.SaveChangesAsync();
            return functionMapped.Id;
        }

        public async Task<bool> DeleteFunction(int functionId)
        {
            var function = await _context.AccessFunctions.SingleOrDefaultAsync(l => l.Id == functionId);
            if (function == null)
            {
                throw new SecurityDbException("Function was not found", ExceptionType.NotFound, EntityType.Function, new []{ functionId .ToString()});
            }

            _context.AccessFunctions.Remove(function);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditFunctionRights(int functionId, int[] newRights)
        {
            var functionDb = await _context.AccessFunctions
                .Include(l=>l.AccessFunctionAccessRights)
                .SingleOrDefaultAsync(l => l.Id == functionId);
            if (functionDb == null)
            {
                throw new SecurityDbException("Function was not found", ExceptionType.NotFound, EntityType.Function, new []{ functionId.ToString() });
            }

            functionDb.AccessFunctionAccessRights.RemoveAll(right => true);
            if (newRights != null && newRights.Length > 0)
            {
                CheckRightsExist(newRights);

                functionDb.AccessFunctionAccessRights.AddRange(newRights
                    .Select(l => new AccessFunctionAccessRight
                    {
                        AccessRightId = l,
                        AccessFunctionId = functionDb.Id
                    }));
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FeatureDb>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            return _mapper.Map<IEnumerable<FeatureDb>>(await _context.Features.Include(l => l.FeatureAccessRight).ThenInclude(l => l.AccessRight)
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync());
        }

        public async Task<int> AddFeature(string featureName)
        {
            if (await _context.Features.AnyAsync(l => featureName.Equals(l.Name)))
            {
                throw new SecurityDbException(
                    "Names already exist", ExceptionType.NameExists, EntityType.Feature, new []{ featureName });
            }
            var featureMapped = _mapper.Map<Feature>(featureName);
            await _context.Features.AddAsync(featureMapped);
            await _context.SaveChangesAsync();
            return featureMapped.Id;
        }

        public async Task<bool> DeleteFeature(int featureId)
        {
            var feature = await _context.Features.SingleOrDefaultAsync(l => l.Id == featureId);
            if (feature == null)
            {
                throw new SecurityDbException("Function was not found", ExceptionType.NotFound, EntityType.Feature, new []{featureId.ToString()});
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditFeatureRights(int featureId, int[] newRights)
        {
            var featureDb = await _context.Features
                .Include(l=>l.FeatureAccessRight)
                .SingleOrDefaultAsync(l => l.Id == featureId);
            if (featureDb == null)
            {
                throw new SecurityDbException("Function was not found", ExceptionType.NotFound, EntityType.Feature, new[] { featureId.ToString() });
            }

            featureDb.FeatureAccessRight.RemoveAll(right => true);
            if (newRights != null && newRights.Length > 0)
            {
                CheckRightsExist(newRights);
                
                featureDb.FeatureAccessRight.AddRange(newRights
                    .Select(l => new FeatureAccessRight
                    {
                        AccessRightId = l,
                        FeatureId = featureDb.Id
                    }));
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoleDb>> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            return _mapper.Map<IEnumerable<RoleDb>>(await _context.Roles
                .Include(l => l.RoleAccessRight).ThenInclude(l=>l.AccessRight)
                .Include(l=>l.RoleAccessFunction).ThenInclude(l=>l.AccessFunction)
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync());
        }

        public async Task<int> AddRole(string roleName)
        {
            if (await _context.Roles.AnyAsync(l => roleName.Equals(l.Name)))
            {
                throw new SecurityDbException(
                    "Names already exist", ExceptionType.NameExists, EntityType.Role, new []{ roleName });
            }
            var roleMapped = _mapper.Map<Role>(roleName);
            await _context.Roles.AddAsync(roleMapped);
            await _context.SaveChangesAsync();
            return roleMapped.Id;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(l => l.Id == roleId);
            if (role == null)
            {
                throw new SecurityDbException("Role was not found", ExceptionType.NotFound, EntityType.Role, new []{ roleId.ToString() });
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditRoleRights(int roleId, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            var roleDb = await _context.Roles
                .Include(l => l.RoleAccessRight)
                .SingleOrDefaultAsync(l => l.Id == roleId);
            if (roleDb == null)
            {
                throw new SecurityDbException("Role was not found", ExceptionType.NotFound, EntityType.Role, new[] { roleId.ToString() });
            }
            
            roleDb.RoleAccessRight.RemoveAll(right => true);

            accessedRightsIds = accessedRightsIds ?? new int[0];
            deniedRightsIds = deniedRightsIds ?? new int[0];

            if (accessedRightsIds.Intersect(deniedRightsIds).Any())
            {
                throw new SecurityDbException("Access Rights in access and denies duplicates.", ExceptionType.Duplicate,
                    EntityType.Right, accessedRightsIds.Intersect(deniedRightsIds).Select(l => l.ToString()).ToArray());
            }

            CheckRightsExist(accessedRightsIds.Union(deniedRightsIds).ToArray());
            
            roleDb.RoleAccessRight.RemoveAll(right => true);

            roleDb.RoleAccessRight.AddRange(accessedRightsIds
                .Select(l => new RoleAccessRight
                {
                    AccessRightId = l,
                    RoleId = roleDb.Id,
                    IsDenied = false
                }));
            roleDb.RoleAccessRight.AddRange(deniedRightsIds
                .Select(l => new RoleAccessRight
                {
                    AccessRightId = l,
                    RoleId = roleDb.Id,
                    IsDenied = true
                }));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditRoleFunctions(int roleId, int[] functionIds)
        {
            var roleDb = await _context.Roles
                .Include(l => l.RoleAccessFunction)
                .SingleOrDefaultAsync(l => l.Id == roleId);
            if (roleDb == null)
            {
                throw new SecurityDbException("Role was not found", ExceptionType.NotFound, EntityType.Role, new[] { roleId.ToString() });
            }

            roleDb.RoleAccessFunction.RemoveAll(right => true);
            if (functionIds != null && functionIds.Length > 0)
            {
                CheckFunctionsExist(functionIds);

                roleDb.RoleAccessFunction.RemoveAll(right => true);
                roleDb.RoleAccessFunction.AddRange(functionIds
                    .Select(l => new RoleAccessFunction()
                    {
                        AccessFunctionId = l,
                        RoleId = roleDb.Id
                    }));
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserRightsDb> GetUserRights(string userId)
        {
            return _mapper.Map<UserRightsDb>(await _context.UsersRights
                .Include(l => l.UserRightsAccessRight).ThenInclude(l => l.AccessRight)
                .Include(l => l.UserRightsAccessFunction).ThenInclude(l => l.AccessFunction)
                .Include(l => l.UserRightsRole).ThenInclude(l => l.Role)
                .SingleOrDefaultAsync(l => l.UserId == userId));
        }

        public async Task<bool> EditUserRights(string userId, int[] roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            var userRightsDb = await _context.UsersRights
                .Include(l => l.UserRightsAccessRight)
                .Include(l => l.UserRightsAccessFunction)
                .Include(l => l.UserRightsRole)
                .SingleOrDefaultAsync(l => l.UserId == userId);
            
            if (userRightsDb == null)
            {
                throw new SecurityDbException(
                    "User rights was not found", ExceptionType.NotFound, EntityType.UserRights, new[] { userId });
            }

            return await EditUserRightsCtx(userRightsDb, roleIds, functionIds, accessedRightsIds, deniedRightsIds);
        }

        public async Task<bool> DeleteUserRights(string userId)
        {
            var userRights = await _context.UsersRights.SingleOrDefaultAsync(l => l.UserId == userId);
            if (userRights == null)
            {
                throw new SecurityDbException("User Rights was not found", ExceptionType.NotFound, EntityType.Role, new[] { userId });
            }

            _context.UsersRights.Remove(userRights);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddUser(UserInfoDb userInfo)
        {
            if (await _context.UsersRights.AnyAsync(l => userInfo.UserId.Equals(l.UserId)))
            {
                throw new SecurityDbException(
                    "UserId already exist", ExceptionType.NameExists, EntityType.UserRights, new[] { userInfo.UserId });
            }
            var userRightsMapped = _mapper.Map<UserRights>(userInfo);
            await _context.UsersRights.AddAsync(userRightsMapped);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(UserInfoDb userInfo)
        {
            var user = await _context.UsersRights.SingleOrDefaultAsync(l => userInfo.UserId.Equals(l.UserId));
            if (user == null)
            {
                throw new SecurityDbException(
                    "UserId not exists", ExceptionType.NotFound, EntityType.UserRights, new[] { userInfo.UserId });
            }

            user.UserLogin = userInfo.UserLogin;
            user.FirstName = userInfo.FirstName;
            user.MiddleName = userInfo.MiddleName;
            user.LastName = userInfo.LastName;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Dictionary<string, bool>> CheckAccess(string userId, string[] accessRightNames)
        {

            var result = new Dictionary<string, bool>(accessRightNames.Select(l => new KeyValuePair<string, bool>(l, false)));
            var accessRightIds = _context.AccessRights.Where(l => accessRightNames.Contains(l.Name)).ToDictionary(l => l.Id, k => k.Name);

            var rights = await _context.UsersRights.Where(l => l.UserId == userId)
                .Include(l => l.UserRightsAccessRight)
                .SelectMany(l => l.UserRightsAccessRight)
                .Where(l => accessRightIds.ContainsKey(l.AccessRightId)).ToArrayAsync();

            var functionsRights = await _context.UsersRights.Where(l => l.UserId == userId)
                .Include(l => l.UserRightsAccessFunction).
                ThenInclude(l=>l.AccessFunction)
                .ThenInclude(l=>l.AccessFunctionAccessRights)
                .SelectMany(l => l.UserRightsAccessFunction.SelectMany(k=>k.AccessFunction.AccessFunctionAccessRights))
                .Where(l => accessRightIds.ContainsKey(l.AccessRightId)).ToArrayAsync();

            var roleRights = await _context.UsersRights.Where(l => l.UserId == userId)
                .Include(l => l.UserRightsRole).
                ThenInclude(l=>l.Role)
                .ThenInclude(l=>l.RoleAccessRight)
                .SelectMany(l => l.UserRightsRole.SelectMany(k=>k.Role.RoleAccessRight))
                .Where(l => accessRightIds.ContainsKey(l.AccessRightId)).ToArrayAsync();

            var roleFunctionRights = await _context.UsersRights.Where(l => l.UserId == userId)
                .Include(l => l.UserRightsRole).
                ThenInclude(l=>l.Role)
                .ThenInclude(l=>l.RoleAccessFunction)
                .ThenInclude(l=>l.AccessFunction)
                .ThenInclude(l=>l.AccessFunctionAccessRights)
                .SelectMany(l => l.UserRightsRole.SelectMany(k=>k.Role.RoleAccessFunction).SelectMany(k=>k.AccessFunction.AccessFunctionAccessRights))
                .Where(l => accessRightIds.ContainsKey(l.AccessRightId)).ToArrayAsync();

            var accessed = rights.Where(l => !l.IsDenied).Select(l => l.AccessRightId)
                .Union(functionsRights.Select(l => l.AccessRightId))
                .Union(roleFunctionRights.Select(l => l.AccessRightId))
                .Union(roleRights.Where(l => !l.IsDenied).Select(l => l.AccessRightId)).ToHashSet();
                
            var denied = rights.Where(l => l.IsDenied).Select(l => l.AccessRightId)
                .Union(roleRights.Where(l => l.IsDenied).Select(l => l.AccessRightId)).ToHashSet();

            foreach (var item in accessRightIds)
            {
                result[item.Value] = accessed.Contains(item.Key) && !denied.Contains(item.Key);
            }

            return result;
        }

        private async Task<bool> EditUserRightsCtx(UserRights userRightsDb, int[] roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            CheckRightsExist(accessedRightsIds.Union(deniedRightsIds).ToArray());

            CheckFunctionsExist(functionIds);

            CheckRolesExist(roleIds);

            userRightsDb.UserRightsAccessRight.RemoveAll(right => true);
            userRightsDb.UserRightsAccessFunction.RemoveAll(right => true);
            userRightsDb.UserRightsRole.RemoveAll(right => true);
            
            userRightsDb.UserRightsAccessRight.AddRange(accessedRightsIds
                .Select(l => new UserRightsAccessRight
                {
                    AccessRightId = l,
                    UserId = userRightsDb.UserId,
                    IsDenied = false
                }));
            userRightsDb.UserRightsAccessRight.AddRange(deniedRightsIds
                .Select(l => new UserRightsAccessRight
                {
                    AccessRightId = l,
                    UserId = userRightsDb.UserId,
                    IsDenied = true
                }));
            userRightsDb.UserRightsAccessFunction.AddRange(functionIds
                .Select(l => new UserRightsAccessFunction
                {
                    AccessFunctionId = l,
                    UserId = userRightsDb.UserId
                }));
            userRightsDb.UserRightsRole.AddRange(roleIds
                .Select(l => new UserRightsRole
                {
                    RoleId = l,
                    UserId = userRightsDb.UserId
                }));

            await _context.SaveChangesAsync();
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            _context.Dispose();
        }

        private void CheckRightsExist(int[] id)
        {
            var found = _context.AccessRights.Where(l => id.Contains(l.Id));
            ThrowIfNotFound(id, found.Select(l => l.Id), EntityType.Right);
        }

        private void CheckFeaturesExist(int[] id)
        {
            var found = _context.Features.Where(l => id.Contains(l.Id)).Select(l => l.Id);
            ThrowIfNotFound(id, found, EntityType.Feature);
        }

        private void CheckFunctionsExist(int[] id)
        {
            var found = _context.AccessFunctions.Where(l => id.Contains(l.Id)).Select(l => l.Id);
            ThrowIfNotFound(id, found, EntityType.Function);
        }

        private void CheckRolesExist(int[] id)
        {
            var found = _context.Roles.Where(l => id.Contains(l.Id)).Select(l => l.Id);
            ThrowIfNotFound(id, found, EntityType.Role);
        }

        private void CheckUserRightsExist(string[] id)
        {
            var found = _context.UsersRights.Where(l => id.Contains(l.UserId)).Select(l => l.UserId);
            var items = id.Except(found.Select(l => l)).Select(l => l.ToString()).ToArray();
            if (items.Any())
            {
                throw new SecurityDbException(
                    "Access rights was not found", ExceptionType.NotFound, EntityType.UserRights, items);
            }
        }

        private void ThrowIfNotFound(int[] id, IQueryable<int> found, EntityType type)
        {
            var items = id.Except(found.Select(l => l)).Select(l => l.ToString()).ToArray();
            if (items.Any())
            {
                throw new SecurityDbException(
                    "Access rights was not found", ExceptionType.NotFound, type, items);
            }
        }

        ~SecurityData()
        {
            Dispose(false);
        }
    }
}
