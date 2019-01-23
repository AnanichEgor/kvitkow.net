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

        internal SecurityData(SecurityContext context, IMapper mapper)
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

        public async Task<AccessRightDb[]> AddRights(AccessRightDb[] accessRights)
        {
            var existed = await _context.AccessRights
                .Where(l => accessRights.Any(k => k.Name.Equals(l.Name)))
                .ToArrayAsync();
            if (existed.Any())
            {
                throw new SecurityDbException(
                    $"Names {string.Join(",", existed.Select(l => l.Name))} already exist");
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
                throw new SecurityDbException($"AccessRight with id = {rightId} was not found");
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

        public async Task<int> AddFunction(AccessFunctionDb function)
        {
            if (await _context.AccessFunctions.AnyAsync(l => function.Name.Equals(l.Name)))
            {
                throw new SecurityDbException(
                    $"Names {function.Name} already exist");
            }
            var featureMapped = _mapper.Map<AccessFunction>(function);
            await _context.AccessFunctions.AddAsync(featureMapped);
            await _context.SaveChangesAsync();
            return featureMapped.Id;
        }

        public async Task<bool> DeleteFunction(int functionId)
        {
            var function = await _context.AccessFunctions.SingleOrDefaultAsync(l => l.Id == functionId);
            if (function == null)
            {
                throw new SecurityDbException($"Function with id = {functionId} was not found");
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
                throw new SecurityDbException($"Function with id = {functionId} was not found");
            }

            var rights = await _context.AccessRights.Where(l => newRights.Contains(l.Id)).ToArrayAsync();
            if (rights.Length != newRights.Length)
            {
                throw new SecurityDbException(
                    $"Access rights with id = {string.Join(",", newRights.Except(rights.Select(l => l.Id)).Select(l => l.ToString()).ToList())} was not found");
            }

            functionDb.AccessFunctionAccessRights.AddRange(rights
                .Select(l => new AccessFunctionAccessRight()
                {
                    AccessRightId = l.Id,
                    AccessFunctionId = functionDb.Id
                }));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FeatureDb>> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            return _mapper.Map<IEnumerable<FeatureDb>>(await _context.Features.Include(l => l.AvailableAccessRights).ThenInclude(l => l.AccessRight)
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync());
        }

        public async Task<int> AddFeature(FeatureDb feature)
        {
            var featureMapped = _mapper.Map<Feature>(feature);
            await _context.Features.AddAsync(featureMapped);
            await _context.SaveChangesAsync();
            return featureMapped.Id;
        }

        public async Task<bool> DeleteFeature(int featureId)
        {
            var feature = await _context.Features.SingleOrDefaultAsync(l => l.Id == featureId);
            if (feature == null)
            {
                throw new SecurityDbException($"Function with id = {featureId} was not found");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditFeatureRules(int featureId, int[] newRights)
        {
            var featureDb = await _context.Features
                .Include(l=>l.AvailableAccessRights)
                .SingleOrDefaultAsync(l => l.Id == featureId);
            if (featureDb == null)
            {
                throw new SecurityDbException($"Function with id = {featureId} was not found");
            }

            var rights = await _context.AccessRights
                .Where(l => newRights.Contains(l.Id)).ToArrayAsync();
            if (rights.Length != newRights.Length)
            {
                throw new SecurityDbException(
                    $"Access rights with id = {string.Join(",", newRights.Except(rights.Select(l => l.Id)).Select(l => l.ToString()).ToList())} was not found");
            }

            featureDb.AvailableAccessRights.AddRange(rights
                .Select(l => new FeatureAccessRight()
                {
                    AccessRightId = l.Id,
                    FeatureId = featureDb.Id
                }));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoleDb>> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            return _mapper.Map<IEnumerable<RoleDb>>(await _context.Roles
                .Include(l => l.AccessRights).ThenInclude(l=>l.AccessRight)
                .Include(l=>l.AccessFunctions).ThenInclude(l=>l.AccessFunction)
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).ToArrayAsync());
        }

        public async Task<int> AddRole(RoleDb role)
        {
            var roleMapped = _mapper.Map<Role>(role);
            await _context.Roles.AddAsync(roleMapped);
            await _context.SaveChangesAsync();
            return roleMapped.Id;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(l => l.Id == roleId);
            if (role == null)
            {
                throw new SecurityDbException($"Role with id = {roleId} was not found");
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditRoleRights(int roleId, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            var roleDb = await _context.Roles
                .Include(l => l.AccessRights)
                .SingleOrDefaultAsync(l => l.Id == roleId);
            if (roleDb == null)
            {
                throw new SecurityDbException($"Role with id = {roleId} was not found");
            }

            var rights = await _context.AccessRights
                .Where(l => accessedRightsIds.Contains(l.Id) || deniedRightsIds.Contains(l.Id)).ToArrayAsync();
            if (rights.Length != accessedRightsIds.Length + deniedRightsIds.Length)
            {
                var notFound = string.Join(",",
                    accessedRightsIds.Except(rights.Select(l => l.Id)).Select(l => l.ToString()), 
                    deniedRightsIds.Except(rights.Select(l => l.Id)).Select(l => l.ToString()));

                throw new SecurityDbException(
                    $"Access rights with id = {notFound} was not found");
            }

            roleDb.AccessRights.AddRange(accessedRightsIds
                .Select(l => new RoleAccessRight()
                {
                    AccessRightId = l,
                    RoleId = roleDb.Id,
                    IsDenied = false
                }));
            roleDb.AccessRights.AddRange(deniedRightsIds
                .Select(l => new RoleAccessRight()
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
                .Include(l => l.AccessFunctions)
                .SingleOrDefaultAsync(l => l.Id == roleId);
            if (roleDb == null)
            {
                throw new SecurityDbException($"Role with id = {roleId} was not found");
            }

            var functions = await _context.AccessFunctions
                .Where(l => functionIds.Contains(l.Id)).ToArrayAsync();
            if (functions.Length != functionIds.Length)
            {
                throw new SecurityDbException(
                    $"Access rights with id = {string.Join(",", functionIds.Except(functions.Select(l => l.Id)).Select(l => l.ToString()).ToList())} was not found");
            }

            roleDb.AccessFunctions.AddRange(functionIds
                .Select(l => new RoleAccessFunction()
                {
                    AccessFunctionId = l,
                    RoleId = roleDb.Id
                }));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserRightsDb> GetUserRights(string userId)
        {
            return _mapper.Map<UserRightsDb>(await _context.UsersRights
                .Include(l => l.AccessRights).ThenInclude(l => l.AccessRight)
                .Include(l => l.AccessFunctions).ThenInclude(l => l.AccessFunction)
                .Include(l => l.Roles).ThenInclude(l => l.Role)
                .SingleOrDefaultAsync(l => l.UserId == userId));
        }

        public async Task<bool> AddNewUserRights(UserRightsDb userRights)
        {
            var userRightsMapped = _mapper.Map<UserRights>(userRights);
            await _context.UsersRights.AddAsync(userRightsMapped);
            return await EditUserRightsCtx(userRightsMapped,
                userRights.Roles.Select(l => l.Id).ToArray(),
                userRights.AccessFunctions.Select(l => l.Id).ToArray(),
                userRights.AccessRights.Select(l => l.Id).ToArray(),
                userRights.DeniedRights.Select(l => l.Id).ToArray());
        }

        public async Task<bool> EditUserRights(string userId, int[] roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            var userRightsDb = await _context.UsersRights
                .Include(l => l.AccessRights)
                .Include(l => l.AccessFunctions)
                .Include(l => l.Roles)
                .SingleOrDefaultAsync(l => l.UserId == userId);
            
            if (userRightsDb == null)
            {
                throw new SecurityDbException(
                    $"User rights with id = {userId} was not found");
            }

            return await EditUserRightsCtx(userRightsDb, roleIds, functionIds, accessedRightsIds, deniedRightsIds);
        }

        private async Task<bool> EditUserRightsCtx(UserRights userRightsDb, int[] roleIds, int[] functionIds, int[] accessedRightsIds, int[] deniedRightsIds)
        {
            var rights = await _context.AccessRights
                .Where(l => accessedRightsIds.Contains(l.Id) || deniedRightsIds.Contains(l.Id)).ToArrayAsync();
            if (rights.Length != accessedRightsIds.Length + deniedRightsIds.Length)
            {
                var notFound = string.Join(",",
                    accessedRightsIds.Except(rights.Select(l => l.Id)).Select(l => l.ToString()),
                    deniedRightsIds.Except(rights.Select(l => l.Id)).Select(l => l.ToString()));

                throw new SecurityDbException(
                    $"Access rights with id = {notFound} was not found");
            }

            var functions = await _context.AccessFunctions
                .Where(l => functionIds.Contains(l.Id)).ToArrayAsync();
            if (functions.Length != functionIds.Length)
            {
                var notFound = string.Join(",",
                    functionIds.Except(functions.Select(l => l.Id)).Select(l => l.ToString()));

                throw new SecurityDbException(
                    $"Access functions with id = {notFound} was not found");
            }

            var roles = await _context.Roles
                .Where(l => roleIds.Contains(l.Id)).ToArrayAsync();
            if (roles.Length != roleIds.Length)
            {
                var notFound = string.Join(",",
                    roleIds.Except(roles.Select(l => l.Id)).Select(l => l.ToString()));

                throw new SecurityDbException(
                    $"Roles with id = {notFound} was not found");
            }

            userRightsDb.AccessRights.RemoveAll(right => true);
            userRightsDb.AccessFunctions.RemoveAll(right => true);
            userRightsDb.Roles.RemoveAll(right => true);
            
            userRightsDb.AccessRights.AddRange(accessedRightsIds
                .Select(l => new UserRightsAccessRight
                {
                    AccessRightId = l,
                    UserId = userRightsDb.UserId,
                    IsDenied = false
                }));
            userRightsDb.AccessRights.AddRange(deniedRightsIds
                .Select(l => new UserRightsAccessRight
                {
                    AccessRightId = l,
                    UserId = userRightsDb.UserId,
                    IsDenied = true
                }));
            userRightsDb.AccessFunctions.AddRange(functionIds
                .Select(l => new UserRightsAccessFunction
                {
                    AccessFunctionId = l,
                    UserId = userRightsDb.UserId
                }));
            userRightsDb.Roles.AddRange(roleIds
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

        ~SecurityData()
        {
            Dispose(false);
        }
    }
}
