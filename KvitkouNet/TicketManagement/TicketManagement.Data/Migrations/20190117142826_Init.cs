using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "LocationAddresses",
                table => new
                {
                    LocationAddressId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_LocationAddresses", x => x.LocationAddressId); });

            migrationBuilder.CreateTable(
                "SellerAddresses",
                table => new
                {
                    SellerAddressId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SellerAddresses", x => x.SellerAddressId); });

            migrationBuilder.CreateTable(
                "Tickets",
                table => new
                {
                    UserInfoDbId = table.Column<string>(nullable: true),
                    Free = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    LocationEventLocationAddressId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    AdditionalData = table.Column<string>(nullable: true),
                    SellerPhone = table.Column<string>(nullable: true),
                    SellerAdressSellerAddressId = table.Column<string>(nullable: true),
                    PaymentSystems = table.Column<string>(nullable: true),
                    TimeActual = table.Column<DateTime>(nullable: false),
                    TypeEvent = table.Column<int>(nullable: false),
                    EventLink = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        "FK_Tickets_LocationAddresses_LocationEventLocationAddressId",
                        x => x.LocationEventLocationAddressId,
                        "LocationAddresses",
                        "LocationAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Tickets_SellerAddresses_SellerAdressSellerAddressId",
                        x => x.SellerAdressSellerAddressId,
                        "SellerAddresses",
                        "SellerAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "UserInfos",
                table => new
                {
                    UserInfoDbId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    TicketDbId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserInfoDbId);
                    table.ForeignKey(
                        "FK_UserInfos_Tickets_TicketDbId",
                        x => x.TicketDbId,
                        "Tickets",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Tickets_LocationEventLocationAddressId",
                "Tickets",
                "LocationEventLocationAddressId");

            migrationBuilder.CreateIndex(
                "IX_Tickets_SellerAdressSellerAddressId",
                "Tickets",
                "SellerAdressSellerAddressId");

            migrationBuilder.CreateIndex(
                "IX_Tickets_UserInfoDbId",
                "Tickets",
                "UserInfoDbId");

            migrationBuilder.CreateIndex(
                "IX_UserInfos_TicketDbId",
                "UserInfos",
                "TicketDbId");

            migrationBuilder.AddForeignKey(
                "FK_Tickets_UserInfos_UserInfoDbId",
                "Tickets",
                "UserInfoDbId",
                "UserInfos",
                principalColumn: "UserInfoDbId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Tickets_LocationAddresses_LocationEventLocationAddressId",
                "Tickets");

            migrationBuilder.DropForeignKey(
                "FK_Tickets_SellerAddresses_SellerAdressSellerAddressId",
                "Tickets");

            migrationBuilder.DropForeignKey(
                "FK_Tickets_UserInfos_UserInfoDbId",
                "Tickets");

            migrationBuilder.DropTable(
                "LocationAddresses");

            migrationBuilder.DropTable(
                "SellerAddresses");

            migrationBuilder.DropTable(
                "UserInfos");

            migrationBuilder.DropTable(
                "Tickets");
        }
    }
}