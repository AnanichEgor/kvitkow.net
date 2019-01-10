﻿// <auto-generated />
using System;
using Logging.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logging.Data.Migrations
{
    [DbContext(typeof(LoggingDbContext))]
    partial class LoggingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Logging.Data.DbModels.AccountLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DeviceDescription");

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("Type");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AccountLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.InternalErrorLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("HResult");

                    b.Property<string>("InnerExceptionString");

                    b.Property<string>("Message");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Source");

                    b.Property<string>("StackTrace");

                    b.Property<string>("TargetSiteName");

                    b.Property<string>("TypeName");

                    b.HasKey("Id");

                    b.ToTable("InternalErrorLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.PaymentLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("TransactionInfo");

                    b.HasKey("Id");

                    b.ToTable("PaymentLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.SearchQueryLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DashBoardFilterInfo");

                    b.Property<DateTime?>("Modified");

                    b.HasKey("Id");

                    b.ToTable("SearchQueryLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.TicketActionLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.HasKey("Id");

                    b.ToTable("TicketActionLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.TicketDealLogEntryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<decimal>("Price");

                    b.Property<string>("Reciever");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("TicketDealLogEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
