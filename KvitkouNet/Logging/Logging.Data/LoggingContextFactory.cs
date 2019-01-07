using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Logging.Data
{
    public class LoggingContextFactory : IDesignTimeDbContextFactory<LoggingDbContext>
    {
        public LoggingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoggingDbContext>();

            optionsBuilder.UseSqlite("Data Source=Logs.db");

            return new LoggingDbContext(optionsBuilder.Options);
        }
    }
}
