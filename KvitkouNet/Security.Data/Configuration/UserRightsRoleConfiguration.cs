using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class UserRightsRoleConfiguration : IEntityTypeConfiguration<UserRightsRole>
    {
        public void Configure(EntityTypeBuilder<UserRightsRole> userRightsRoleEntity)
        {
            userRightsRoleEntity.HasKey(bc => new { bc.UserId, bc.RoleId });
            userRightsRoleEntity.HasIndex(l => l.UserId);
            userRightsRoleEntity
                .HasOne<UserRights>(bc => bc.UserRights)
                .WithMany(b => b.Roles)
                .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.SetNull);
            userRightsRoleEntity
                .HasOne<Role>(bc => bc.Role)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
