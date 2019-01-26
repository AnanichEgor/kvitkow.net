using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dashboard.Data.Context
{
    class ImplementIDbContextFactory : IDesignTimeDbContextFactory<DashboardContext>
    {
        public DashboardContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<DashboardContext>();

            var connectionString = "Data Source = ./News.db";

            builder.UseSqlite(connectionString);

            return new DashboardContext(builder.Options);
        }
    }
}