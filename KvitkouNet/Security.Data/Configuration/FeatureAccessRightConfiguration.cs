using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class FeatureAccessRightConfiguration : IEntityTypeConfiguration<FeatureAccessRight>
    {
        public void Configure(EntityTypeBuilder<FeatureAccessRight> featureAccessRightEntity)
        {
            featureAccessRightEntity.HasKey(bc => new { bc.FeatureId, bc.AccessRightId });
            featureAccessRightEntity.HasIndex(l => l.FeatureId);
            featureAccessRightEntity
                .HasOne<Feature>(bc => bc.Feature)
                .WithMany(b => b.AvailableAccessRights)
                .HasForeignKey(bc => bc.FeatureId).OnDelete(DeleteBehavior.SetNull);
            featureAccessRightEntity
                .HasOne<AccessRight>(bc => bc.AccessRight)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
