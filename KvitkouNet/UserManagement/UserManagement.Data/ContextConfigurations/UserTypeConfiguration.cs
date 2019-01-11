using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.ContextConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserDB>
    {
        public void Configure(EntityTypeBuilder<UserDB> builder)
        {
            //builder.ToTable("Users")
            //    .HasKey(keyExpression: x => x.Id);
            builder.HasOne(navigationExpression: x => x.Account)
                .WithOne()
                .HasForeignKey<AccountDB>(x=>x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(navigationExpression: x => x.Profile)
                .WithOne()
                .HasForeignKey<ProfileDB>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(navigationExpression: x => x.Tickets)
                .WithOne(x => x.User);
        }
    }
}