﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StatisticUser.Data;

namespace StatisticUser.Data.Migrations
{
    [DbContext(typeof(WebApiContext))]
    partial class WebApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("StatisticUser.Data.DbModels.MessagesUsersOnSiteDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("MessageCount");

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("MessagesUsersOnSiteDB");
                });

            modelBuilder.Entity("StatisticUser.Data.DbModels.OpenResourcesDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("Modified");

                    b.Property<int?>("ResourceIdId");

                    b.Property<TimeSpan>("TimeOnResource");

                    b.HasKey("Id");

                    b.HasIndex("ResourceIdId");

                    b.ToTable("OpenResourcesDb");
                });

            modelBuilder.Entity("StatisticUser.Data.DbModels.RatingDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("Negative");

                    b.Property<int>("Positive");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("RatingDB");
                });

            modelBuilder.Entity("StatisticUser.Data.DbModels.ResourcesUrlDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("ResourceUrl");

                    b.HasKey("Id");

                    b.ToTable("ResourcesUrlDB");
                });

            modelBuilder.Entity("StatisticUser.Data.DbModels.TimeOnSiteDB", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DataTimeAuthorization");

                    b.Property<DateTime?>("Modified");

                    b.Property<TimeSpan>("TimeOnline");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TimeOnSiteDB");
                });

            modelBuilder.Entity("StatisticUser.Data.DbModels.OpenResourcesDb", b =>
                {
                    b.HasOne("StatisticUser.Data.DbModels.ResourcesUrlDB", "ResourceId")
                        .WithMany()
                        .HasForeignKey("ResourceIdId");
                });
#pragma warning restore 612, 618
        }
    }
}
