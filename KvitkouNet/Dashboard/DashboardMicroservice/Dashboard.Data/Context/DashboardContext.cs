using Microsoft.EntityFrameworkCore;
using Dashboard.Data.DbModels;

namespace Dashboard.Data.Context
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        public DbSet<NewsDb> News { get; set; }

        public DbSet<TicketInfoDb> LocationAddresses { get; set; }

        public DbSet<UserInfoDb> UserInfos { get; set; }
    }
}
