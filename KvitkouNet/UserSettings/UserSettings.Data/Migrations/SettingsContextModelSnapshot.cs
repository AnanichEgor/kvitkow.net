﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserSettings.Data.Context;

namespace UserSettings.Data.Migrations
{
    [DbContext(typeof(SettingsContext))]
    partial class SettingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("UserSettings.Data.DbModels.NotificationDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsLikeMyTicket");

                    b.Property<bool>("IsOtherNotification");

                    b.Property<bool>("IsWantBuy");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("UserSettings.Data.DbModels.SettingsDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsGetTicketInfo");

                    b.Property<bool>("IsPrivateAccount");

                    b.Property<int?>("NotificationsId");

                    b.Property<string>("PreferAddress");

                    b.Property<string>("PreferPlace");

                    b.Property<string>("PreferRegion");

                    b.Property<byte[]>("UserImage");

                    b.HasKey("Id");

                    b.HasIndex("NotificationsId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("UserSettings.Data.DbModels.SettingsDb", b =>
                {
                    b.HasOne("UserSettings.Data.DbModels.NotificationDb", "Notifications")
                        .WithMany()
                        .HasForeignKey("NotificationsId");
                });
#pragma warning restore 612, 618
        }
    }
}
