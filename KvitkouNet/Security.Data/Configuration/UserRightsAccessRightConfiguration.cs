using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class UserRightsAccessRightConfiguration : IEntityTypeConfiguration<UserRightsAccessRight>
    {
        public void Configure(EntityTypeBuilder<UserRightsAccessRight> userRightsAccessRightEntity)
        {
            userRightsAccessRightEntity.HasKey(bc => new { bc.UserId, bc.AccessRightId });
            userRightsAccessRightEntity.HasKey(l => l.UserId);
            userRightsAccessRightEntity
                .HasOne<UserRights>(bc => bc.UserRights)
                .WithMany(b => b.AccessRights)
                .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.SetNull);
            userRightsAccessRightEntity
                .HasOne<AccessRight>(bc => bc.AccessRight)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
