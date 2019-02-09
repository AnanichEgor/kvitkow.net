using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dashboard.Data.Context
{
    class ImplementIDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DashboardContext>
    {
        public DashboardContext CreateDbContext(string[] args)
        {

          var builder = new DbContextOptionsBuilder<DashboardContext>();

            var connectionString = "Data Source=./NewsDatabase.db";

            builder.UseLazyLoadingProxies().UseSqlite(connectionString);

            return new DashboardContext(builder.Options);
        }
    }
}
