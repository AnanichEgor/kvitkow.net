﻿// <auto-generated />
using System;
using Logging.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logging.Data.Migrations
{
    [DbContext(typeof(LoggingDbContext))]
    [Migration("20190120165022_FixDbModels")]
    partial class FixDbModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Logging.Data.DbModels.AccountLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DeviceDescription");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AccountLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.InternalErrorLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("ExceptionType");

                    b.Property<int>("HResult");

                    b.Property<string>("InnerExceptionString");

                    b.Property<string>("Message");

                    b.Property<string>("Source");

                    b.Property<string>("StackTrace");

                    b.Property<string>("TargetSiteName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("InternalErrorLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.PaymentLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("TransactionInfo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("PaymentLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.SearchQueryLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DashBoardFilterInfo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("SearchQueryLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.TicketActionLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TicketActionLogEntries");
                });

            modelBuilder.Entity("Logging.Data.DbModels.TicketDealLogEntryDbModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Price");

                    b.Property<string>("Reciever");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TicketDealLogEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
