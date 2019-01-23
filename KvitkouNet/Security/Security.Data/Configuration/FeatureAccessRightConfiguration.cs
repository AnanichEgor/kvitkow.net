using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.ContextModels;

namespace Security.Data.Configuration
{
    internal class FeatureAccessRightConfiguration : IEntityTypeConfiguration<FeatureAccessRight>
    {
        public void Configure(EntityTypeBuilder<FeatureAccessRight> featureAccessRightEntity)
        {
            featureAccessRightEntity.HasKey(bc => new { bc.FeatureId, bc.AccessRightId });
            featureAccessRightEntity.HasIndex(l => l.FeatureId);
            featureAccessRightEntity
                .HasOne<Feature>(bc => bc.Feature)
                .WithMany(b => b.AvailableAccessRights)
                .HasForeignKey(bc => bc.FeatureId)
                .OnDelete(DeleteBehavior.SetNull);
            featureAccessRightEntity
                .HasOne<AccessRight>(bc => bc.AccessRight)
                .WithMany(l=>l.AvailableAccessRights)
                .HasForeignKey(l=>l.AccessRightId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
