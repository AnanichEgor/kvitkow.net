using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Data.Context;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.Repositories
{
    class GroupRepository : BaseRepository<GroupDB>
    {
        protected readonly UserContext _context;
        public GroupRepository(UserContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
