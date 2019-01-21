﻿// <auto-generated />
using System;
using Chat.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chat.Data.Migrations
{
    [DbContext(typeof(ChatContext))]
    partial class ChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Chat.Data.DbModels.MessageDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRead");

                    b.Property<string>("RoomId");

                    b.Property<DateTime>("SendedTime");

                    b.Property<string>("Text");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Chat.Data.DbModels.RoomDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPrivat");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Chat.Data.DbModels.SettingsDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BackgroundColor");

                    b.Property<bool>("DisablePrivateMessages");

                    b.Property<bool>("HideChat");

                    b.Property<int>("HistoryCountsMessages");

                    b.Property<bool>("Sound");

                    b.Property<bool>("Tab");

                    b.Property<bool>("Toast");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<bool>("ViewTimestampsMessage");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Chat.Data.DbModels.UserDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("RoomId");

                    b.Property<string>("SettingsId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserName");

                    b.Property<string>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SettingsId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Chat.Data.DbModels.MessageDb", b =>
                {
                    b.HasOne("Chat.Data.DbModels.RoomDb", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("Chat.Data.DbModels.UserDb", b =>
                {
                    b.HasOne("Chat.Data.DbModels.RoomDb", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("Chat.Data.DbModels.SettingsDb", "Settings")
                        .WithOne("User")
                        .HasForeignKey("Chat.Data.DbModels.UserDb", "SettingsId");
                });
#pragma warning restore 612, 618
        }
    }
}
