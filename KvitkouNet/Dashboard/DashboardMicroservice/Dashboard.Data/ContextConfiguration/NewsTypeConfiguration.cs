using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dashboard.Data.DbModels;

namespace Dashboard.Data.ContextConfiguration
{
    internal class NewsTypeConfiguration : IEntityTypeConfiguration<NewsDb>
    {
        public void Configure(EntityTypeBuilder<NewsDb> builder)
        {
            builder.ToTable("News")
                .HasKey(keyExpression: x => x.NewsId);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(navigationExpression: x => x.UserInfo)
                .WithOne()
                .HasForeignKey<UserInfoDb>(x => x.UserInfoDbId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(navigationExpression: x => x.TicketInfo)
                .WithOne()
                .HasForeignKey<TicketInfoDb>(x => x.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
