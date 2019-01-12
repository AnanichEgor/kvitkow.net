using System;
using System.Collections.Generic;
using System.Text;
using Security.Data.Context;

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
