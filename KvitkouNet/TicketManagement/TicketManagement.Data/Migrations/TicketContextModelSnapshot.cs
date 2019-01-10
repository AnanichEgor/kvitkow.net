﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketManagement.Data.Context;

namespace TicketManagement.Data.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("TicketManagement.Data.DbModels.AddressDb", b =>
                {
                    b.Property<string>("AddressDbId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Flat");

                    b.Property<string>("House");

                    b.Property<string>("Street");

                    b.HasKey("AddressDbId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("TicketManagement.Data.DbModels.TicketDb", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalData");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EventLink");

                    b.Property<bool>("Free");

                    b.Property<string>("LocationEventAddressDbId");

                    b.Property<string>("Name");

                    b.Property<string>("PaymentSystems");

                    b.Property<decimal?>("Price");

                    b.Property<string>("SellerAdressAddressDbId");

                    b.Property<string>("SellerPhone");

                    b.Property<int>("Status");

                    b.Property<DateTime>("TimeActual");

                    b.Property<int>("TypeEvent");

                    b.Property<string>("UserInfoDbId");

                    b.HasKey("Id");

                    b.HasIndex("LocationEventAddressDbId");

                    b.HasIndex("SellerAdressAddressDbId");

                    b.HasIndex("UserInfoDbId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketManagement.Data.DbModels.UserInfoDb", b =>
                {
                    b.Property<string>("UserInfoDbId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<double?>("Rating");

                    b.Property<string>("TicketDbId");

                    b.HasKey("UserInfoDbId");

                    b.HasIndex("TicketDbId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("TicketManagement.Data.DbModels.TicketDb", b =>
                {
                    b.HasOne("TicketManagement.Data.DbModels.AddressDb", "LocationEvent")
                        .WithMany()
                        .HasForeignKey("LocationEventAddressDbId");

                    b.HasOne("TicketManagement.Data.DbModels.AddressDb", "SellerAdress")
                        .WithMany()
                        .HasForeignKey("SellerAdressAddressDbId");

                    b.HasOne("TicketManagement.Data.DbModels.UserInfoDb", "User")
                        .WithMany()
                        .HasForeignKey("UserInfoDbId");
                });

            modelBuilder.Entity("TicketManagement.Data.DbModels.UserInfoDb", b =>
                {
                    b.HasOne("TicketManagement.Data.DbModels.TicketDb")
                        .WithMany("RespondedUsers")
                        .HasForeignKey("TicketDbId");
                });
#pragma warning restore 612, 618
        }
    }
}
