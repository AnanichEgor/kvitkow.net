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

        public async void DeleteRight(int rightId)
        {
            var right = await _context.AccessRights.SingleOrDefaultAsync(l => l.Id == rightId);
            if (right == null)
            {
                throw new SecurityDbException($"AccessRight with id = {rightId} was not found");
            }

            _context.AccessRights.Remove(right);
            await _context.SaveChangesAsync();
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

        public async void DeleteFunction(int functionId)
        {
            var function = await _context.AccessFunctions.SingleOrDefaultAsync(l => l.Id == functionId);
            if (function == null)
            {
                throw new SecurityDbException($"Function with id = {functionId} was not found");
            }

            _context.AccessFunctions.Remove(function);
            await _context.SaveChangesAsync();
        }

        public async void EditFunctionRights(int functionId, int[] newRights)
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

        public void DeleteFeature(int featureId)
        {
            throw new NotImplementedException();
        }

        public async void EditFeatureRules(int featureId, int[] newRights)
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
        }

        public Task<IEnumerable<RoleDb>> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new NotImplementedException();
        }

        public int AddRole(RoleDb role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public void EditRole(RoleDb role)
        {
            throw new NotImplementedException();
        }

        public UserRightsDb GetUserRights(string userId)
        {
            throw new NotImplementedException();
        }

        public void EditUserRights(UserRightsDb userRights)
        {
            throw new NotImplementedException();
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
