using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticUser.Data.DbModels;

namespace StatisticOnline.Data.Context
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }

        public DbSet<MessagesUsersOnSiteDB> MessagesUsersOnSite { get; set; }
        public DbSet<OpenResourcesDb> OpenResources { get; set; }
        public DbSet<RatingDB> Rating { get; set; }
        public DbSet<ResourcesUrlDB> ResourcesUrl { get; set; }
        public DbSet<TimeOnSiteDB> TimeOnSite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookTypeConfiguration());
        }

        public class BookTypeConfiguration : IEntityTypeConfiguration<StatisticUserDb>
        {
            public void Configure(EntityTypeBuilder<StatisticUserDb> builder)
            {
                builder.ToTable("StatisticUserDb")
                    .HasKey(x => x.Id);

                builder.Property(x => x.UserId)
                    .IsRequired();

                builder.Property(x => x.CountInputs)
                    .IsRequired()
                    .HasDefaultValue(0);

                builder.Property(x => x.CountMessages)
                    .IsRequired()
                    .HasDefaultValue(0);

                builder.Property(x => x.Rating)
                    .IsRequired()
                    .HasDefaultValue(0);

                builder.Property(x => x.Rating)
                    .IsRequired()
                    .HasDefaultValue(0);
            }
        }

    }
}
