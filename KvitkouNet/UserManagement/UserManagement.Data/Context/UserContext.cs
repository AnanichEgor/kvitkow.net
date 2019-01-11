using Microsoft.EntityFrameworkCore;
using UserManagement.Data.ContextConfigurations;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
        }
        public DbSet<UserDB> Users { get; set; }
        public DbSet<AccountDB> Accounts { get; set; }
        public DbSet<ProfileDB> Profiles { get; set; }
        public DbSet<PhoneNumberDB> PhoneNumbers { get; set; }
        public DbSet<AddressDB> Adresses { get; set; }
        public DbSet<GroupDB> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserGroupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
        }
    }
}
