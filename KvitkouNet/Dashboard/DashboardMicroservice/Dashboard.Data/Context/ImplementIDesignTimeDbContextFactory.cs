using Dashboard.Data.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace Dashboard.Data.Context
{
    class ImplementIDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DashboardContext>
    {
        public DashboardContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<DashboardContext>();

            builder.UseSqlite("Data Source = ./NewsDatabase.db");

            using (var ctx = new DashboardContext(builder.Options))
            {
                ctx.Database.Migrate();
                if (!ctx.News.Any())
                {
                    ctx.News.AddRange(NewsFaker.Generate(50));
                    ctx.SaveChanges();
                }
            }

            return new DashboardContext(builder.Options);
        }
    }
}
