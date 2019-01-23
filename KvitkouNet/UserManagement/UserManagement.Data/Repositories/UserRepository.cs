using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Data.Context;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.Repositories
{
    public class UserRepository : BaseRepository<UserDB>
    {
        protected readonly UserContext _context;
        public UserRepository(UserContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
