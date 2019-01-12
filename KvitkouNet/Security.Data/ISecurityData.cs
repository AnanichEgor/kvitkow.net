using System;
using System.Collections.Generic;
using System.Text;
using Security.Data.Models;

namespace Security.Data
{
    public interface ISecurityData : IDisposable
    {
        IEnumerable<AccessRightDb> GetRights(int itemsPerPage, int pageNumber, string mask);
    }
}
