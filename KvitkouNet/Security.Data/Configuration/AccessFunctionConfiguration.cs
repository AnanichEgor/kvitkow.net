using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    internal class AccessFunctionConfiguration : IEntityTypeConfiguration<AccessFunction>
    {
        public void Configure(EntityTypeBuilder<AccessFunction> accessFunctionEntity)
        {
            accessFunctionEntity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            accessFunctionEntity.HasOne<Feature>()
                .WithMany()
                .HasForeignKey(x => x.FeatureId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
