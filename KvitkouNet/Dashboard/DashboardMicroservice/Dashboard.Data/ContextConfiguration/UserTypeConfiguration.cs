using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dashboard.Data.DbModels;

namespace Dashboard.Data.ContextConfiguration
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserInfoDb>
    {
        public void Configure(EntityTypeBuilder<UserInfoDb> builder)
        {
            builder.ToTable("User")
                .HasKey(keyExpression: x => x.UserInfoDbId);

        }
    }
}
