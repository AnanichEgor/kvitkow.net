using Microsoft.EntityFrameworkCore;

namespace Logging.Data
{
    public sealed class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
