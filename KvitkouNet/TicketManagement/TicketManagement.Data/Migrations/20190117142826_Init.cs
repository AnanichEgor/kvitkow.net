using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationAddresses",
                columns: table => new
                {
                    LocationAddressId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationAddresses", x => x.LocationAddressId);
                });

            migrationBuilder.CreateTable(
                name: "SellerAddresses",
                columns: table => new
                {
                    SellerAddressId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerAddresses", x => x.SellerAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
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
                        name: "FK_Tickets_LocationAddresses_LocationEventLocationAddressId",
                        column: x => x.LocationEventLocationAddressId,
                        principalTable: "LocationAddresses",
                        principalColumn: "LocationAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_SellerAddresses_SellerAdressSellerAddressId",
                        column: x => x.SellerAdressSellerAddressId,
                        principalTable: "SellerAddresses",
                        principalColumn: "SellerAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
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
                        name: "FK_UserInfos_Tickets_TicketDbId",
                        column: x => x.TicketDbId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocationEventLocationAddressId",
                table: "Tickets",
                column: "LocationEventLocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SellerAdressSellerAddressId",
                table: "Tickets",
                column: "SellerAdressSellerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserInfoDbId",
                table: "Tickets",
                column: "UserInfoDbId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_TicketDbId",
                table: "UserInfos",
                column: "TicketDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_UserInfos_UserInfoDbId",
                table: "Tickets",
                column: "UserInfoDbId",
                principalTable: "UserInfos",
                principalColumn: "UserInfoDbId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_LocationAddresses_LocationEventLocationAddressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_SellerAddresses_SellerAdressSellerAddressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserInfos_UserInfoDbId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "LocationAddresses");

            migrationBuilder.DropTable(
                name: "SellerAddresses");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
