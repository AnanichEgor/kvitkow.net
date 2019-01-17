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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketDb>()
                .HasOne(p => p.User)
                .WithMany(b => b.UserTickets)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TicketDb>()
               .HasOne(p => p.SellerAdress)
               .WithMany(b => b.Tickets)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }

}