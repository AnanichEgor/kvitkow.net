﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Security.Data.Context;

namespace Security.Data.Migrations
{
    [DbContext(typeof(SecurityContext))]
    [Migration("20190111204951_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Security.Data.Models.AccessFunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FeatureId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("AccessFunctions");
                });

            modelBuilder.Entity("Security.Data.Models.AccessFunctionAccessRight", b =>
                {
                    b.Property<int>("AccessFunctionId");

                    b.Property<int>("AccessRightId");

                    b.HasKey("AccessFunctionId", "AccessRightId");

                    b.HasIndex("AccessFunctionId");

                    b.HasIndex("AccessRightId")
                        .IsUnique();

                    b.ToTable("AccessFunctionAccessRight");
                });

            modelBuilder.Entity("Security.Data.Models.AccessRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("AccessRights");
                });

            modelBuilder.Entity("Security.Data.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Security.Data.Models.FeatureAccessRight", b =>
                {
                    b.Property<int>("FeatureId");

                    b.Property<int>("AccessRightId");

                    b.HasKey("FeatureId", "AccessRightId");

                    b.HasIndex("AccessRightId")
                        .IsUnique();

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureAccessRight");
                });

            modelBuilder.Entity("Security.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Security.Data.Models.RoleAccessFunction", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("AccessFunctionId");

                    b.HasKey("RoleId", "AccessFunctionId");

                    b.HasIndex("AccessFunctionId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAccessFunction");
                });

            modelBuilder.Entity("Security.Data.Models.RoleAccessRight", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("AccessRightId");

                    b.Property<bool>("IsDenied");

                    b.HasKey("RoleId", "AccessRightId");

                    b.HasIndex("AccessRightId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("RoleAccessRight");
                });

            modelBuilder.Entity("Security.Data.Models.UserRights", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100);

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("UserId");

                    b.ToTable("UsersRights");
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsAccessFunction", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("AccessFunctionId");

                    b.HasKey("UserId");

                    b.HasAlternateKey("UserId", "AccessFunctionId");

                    b.HasIndex("AccessFunctionId")
                        .IsUnique();

                    b.ToTable("UserRightsAccessFunction");
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsAccessRight", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("AccessRightId");

                    b.Property<bool>("IsDenied");

                    b.HasKey("UserId");

                    b.HasAlternateKey("UserId", "AccessRightId");

                    b.HasIndex("AccessRightId")
                        .IsUnique();

                    b.ToTable("UserRightsAccessRight");
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserRightsRole");
                });

            modelBuilder.Entity("Security.Data.Models.AccessFunction", b =>
                {
                    b.HasOne("Security.Data.Models.Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.AccessFunctionAccessRight", b =>
                {
                    b.HasOne("Security.Data.Models.AccessFunction", "AccessFunction")
                        .WithMany("AccessFunctionAccessRights")
                        .HasForeignKey("AccessFunctionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.AccessRight", "AccessRight")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.AccessFunctionAccessRight", "AccessRightId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.FeatureAccessRight", b =>
                {
                    b.HasOne("Security.Data.Models.AccessRight", "AccessRight")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.FeatureAccessRight", "AccessRightId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.Feature", "Feature")
                        .WithMany("AvailableAccessRights")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.RoleAccessFunction", b =>
                {
                    b.HasOne("Security.Data.Models.AccessFunction", "AccessFunction")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.RoleAccessFunction", "AccessFunctionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.Role", "Role")
                        .WithMany("AccessFunctions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.RoleAccessRight", b =>
                {
                    b.HasOne("Security.Data.Models.AccessRight", "AccessRight")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.RoleAccessRight", "AccessRightId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.Role", "Role")
                        .WithMany("AccessRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsAccessFunction", b =>
                {
                    b.HasOne("Security.Data.Models.AccessFunction", "AccessFunction")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.UserRightsAccessFunction", "AccessFunctionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.UserRights", "UserRights")
                        .WithMany("AccessFunctions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsAccessRight", b =>
                {
                    b.HasOne("Security.Data.Models.AccessRight", "AccessRight")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.UserRightsAccessRight", "AccessRightId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.UserRights", "UserRights")
                        .WithMany("AccessRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Security.Data.Models.UserRightsRole", b =>
                {
                    b.HasOne("Security.Data.Models.Role", "Role")
                        .WithOne()
                        .HasForeignKey("Security.Data.Models.UserRightsRole", "RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Security.Data.Models.UserRights", "UserRights")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
