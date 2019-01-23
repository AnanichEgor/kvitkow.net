using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.ContextModels;

namespace Security.Data.Configuration
{
    internal class AccessFunctionAccessRightConfiguration : IEntityTypeConfiguration<AccessFunctionAccessRight>
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
                .WithMany(l=>l.AccessFunctionAccessRights)
                .HasForeignKey(l=>l.AccessRightId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
