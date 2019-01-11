using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> featureEntity)
        {
            featureEntity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
