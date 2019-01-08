using Microsoft.EntityFrameworkCore;
using UserManagement.Logic.Common.Models;

namespace UserManagement.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
            //Database.EnsureDeleted();
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
