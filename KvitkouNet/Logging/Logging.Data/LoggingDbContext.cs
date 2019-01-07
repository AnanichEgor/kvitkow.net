using Logging.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Logging.Data
{
    public sealed class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AccountLogEntryDbModel> AccountLogEntries { get; set; }

        public DbSet<InternalErrorLogEntryDbModel> InternalErrorLogEntries { get; set; }
    }
}
