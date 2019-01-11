using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.Models;

namespace Security.Data.Configuration
{
    class UserRightsAccessFunctionConfiguration : IEntityTypeConfiguration<UserRightsAccessFunction>
    {
        public void Configure(EntityTypeBuilder<UserRightsAccessFunction> userRightsAccessFunctionEntity)
        {
            userRightsAccessFunctionEntity.HasKey(bc => new { bc.UserId, bc.AccessFunctionId });
            userRightsAccessFunctionEntity.HasKey(l => l.UserId);
            userRightsAccessFunctionEntity
                .HasOne<UserRights>(bc => bc.UserRights)
                .WithMany(b => b.AccessFunctions)
                .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.SetNull);
            userRightsAccessFunctionEntity
                .HasOne<AccessFunction>(bc => bc.AccessFunction)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
