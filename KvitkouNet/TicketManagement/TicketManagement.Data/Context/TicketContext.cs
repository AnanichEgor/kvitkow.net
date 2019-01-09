using Microsoft.EntityFrameworkCore;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Data.Context
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }
        public DbSet<TicketDb> Tickets { get; set; }
        public DbSet<AddressDb> Adresses { get; set; }
        public DbSet<UserInfoDb> UserInfos { get; set; }
    }
}