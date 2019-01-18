using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.ContextModels;

namespace Security.Data.Configuration
{
    internal class RoleAccessRightConfiguration : IEntityTypeConfiguration<RoleAccessRight>
    {
        public void Configure(EntityTypeBuilder<RoleAccessRight> roleAccessRightEntity)
        {
            roleAccessRightEntity.HasKey(bc => new { bc.RoleId, bc.AccessRightId });
            roleAccessRightEntity.HasIndex(l => l.RoleId);
            roleAccessRightEntity
                .HasOne<Role>(bc => bc.Role)
                .WithMany(b => b.AccessRights)
                .HasForeignKey(bc => bc.RoleId).OnDelete(DeleteBehavior.SetNull);
            roleAccessRightEntity
                .HasOne<AccessRight>(bc => bc.AccessRight)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
