using System;
using System.Collections.Generic;
using System.Text;
using Security.Data.Context;
using Security.Data.Models;

namespace Security.Data
{
    public class SecurityData : ISecurityData
    {
        private SecurityContext _context;

        private SecurityData(SecurityContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AccessRightDb> GetRights(int itemsPerPage, int pageNumber, string mask)
        {
            throw new NotImplementedException();
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
