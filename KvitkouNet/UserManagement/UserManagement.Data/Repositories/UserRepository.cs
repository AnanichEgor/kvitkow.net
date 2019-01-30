using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Data.Context;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.Repositories
{
    public class UserRepository : BaseRepository<UserDB>, IUserRepository
    {
        public UserRepository(UserContext db) : base(db) { }
    }
}
