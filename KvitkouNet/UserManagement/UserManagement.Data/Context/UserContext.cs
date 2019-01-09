using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Logic.Common.Models;
using UserManagement.Logic.Common.Models.Security;
using UserManagement.Logic.Common.Models.Tickets;
using UserManagement.Logic.Common.Models.UserSettings;

namespace UserManagement.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
