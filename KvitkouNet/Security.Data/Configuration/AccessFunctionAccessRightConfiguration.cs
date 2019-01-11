using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class AccessFunctionAccessRightConfiguration : IEntityTypeConfiguration<AccessFunctionAccessRight>
    {
        public void Configure(EntityTypeBuilder<AccessFunctionAccessRight> accessFunctionAccessRightEntity)
        {
            accessFunctionAccessRightEntity.HasKey(bc => new { bc.AccessFunctionId, bc.AccessRightId });
            accessFunctionAccessRightEntity.HasIndex(l => l.AccessFunctionId);
            accessFunctionAccessRightEntity
                .HasOne<AccessFunction>(bc => bc.AccessFunction)
                .WithMany(b => b.AccessFunctionAccessRights)
                .HasForeignKey(bc => bc.AccessFunctionId)
                .OnDelete(DeleteBehavior.SetNull);
            accessFunctionAccessRightEntity
                .HasOne<AccessRight>(bc => bc.AccessRight)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
