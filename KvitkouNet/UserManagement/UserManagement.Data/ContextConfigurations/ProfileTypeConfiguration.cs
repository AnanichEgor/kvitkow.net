using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Data.DbModels;

namespace UserManagement.Data.ContextConfigurations
{
    internal class ProfileTypeConfiguration : IEntityTypeConfiguration<ProfileDB>
    {
        public void Configure(EntityTypeBuilder<ProfileDB> builder)
        {
            builder.ToTable("Profiles")
                .HasKey(keyExpression: x => x.Id);
        }
    }
}