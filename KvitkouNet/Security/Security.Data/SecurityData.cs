using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Security.Data.Context;
using Security.Data.ContextModels;
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

        public IEnumerable<AccessRightDb> GetRights(int itemsPerPage, int pageNumber, string mask)
        {
            return _mapper.Map<IEnumerable<AccessRightDb>>(_context.AccessRights
                .Where(l => l.Name.Contains(mask))
                .OrderBy(l => l.Name)
                .Skip(itemsPerPage * (pageNumber - 1)).Take(itemsPerPage).AsEnumerable());
        }

        public int AddRight(AccessRightDb accessRight)
        {
            var right = _mapper.Map<AccessRight>(accessRight);
            _context.AccessRights.Add(right);
            _context.SaveChanges();
            return right.Id;
        }

        public int AddRight(AccessRightDb right)
        {
            throw new NotImplementedException();
        }

        public void DeleteRight(int rightId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccessFunctionDb> GetFunctions(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new NotImplementedException();
        }

        public int AddFunction(AccessFunctionDb function)
        {
            throw new NotImplementedException();
        }

        public void DeleteFunction(int functionId)
        {
            throw new NotImplementedException();
        }

        public void EditFunction(AccessFunctionDb function)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeatureDb> GetFeatures(int itemsPerPage, int pageNumber, string mask = null)
        {
            throw new NotImplementedException();
        }

        public int AddFeature(FeatureDb feature)
        {
            throw new NotImplementedException();
        }

        public void DeleteFeature(int featureId)
        {
            throw new NotImplementedException();
        }

        public void EditFeature(FeatureDb feature)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleDb> GetRoles(int itemsPerPage, int pageNumber, string mask = null)
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
