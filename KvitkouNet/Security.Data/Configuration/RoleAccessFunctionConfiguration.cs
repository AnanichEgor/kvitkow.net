﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Data.ContextModels;

namespace Security.Data.Configuration
{
    internal class RoleAccessFunctionConfiguration : IEntityTypeConfiguration<RoleAccessFunction>
    {
        public void Configure(EntityTypeBuilder<RoleAccessFunction> roleAccessFunctionEntity)
        {
            roleAccessFunctionEntity.HasKey(bc => new { bc.RoleId, bc.AccessFunctionId });
            roleAccessFunctionEntity.HasIndex(l => l.RoleId);
            roleAccessFunctionEntity
                .HasOne<Role>(bc => bc.Role)
                .WithMany(b => b.AccessFunctions)
                .HasForeignKey(bc => bc.RoleId).OnDelete(DeleteBehavior.SetNull);
            roleAccessFunctionEntity
                .HasOne<AccessFunction>(bc => bc.AccessFunction)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
