using Microsoft.EntityFrameworkCore;
using Dashboard.Data.DbModels;
<<<<<<< HEAD
using Dashboard.Data.ContextConfiguration;
=======
>>>>>>> DashboardMicroservice

namespace Dashboard.Data.Context
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        public DbSet<NewsDb> News { get; set; }
<<<<<<< HEAD
        public DbSet<TicketInfoDb> LocationAddresses { get; set; }
        public DbSet<UserInfoDb> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }
=======

        public DbSet<TicketInfoDb> LocationAddresses { get; set; }

        public DbSet<UserInfoDb> UserInfos { get; set; }
>>>>>>> DashboardMicroservice
    }
}
