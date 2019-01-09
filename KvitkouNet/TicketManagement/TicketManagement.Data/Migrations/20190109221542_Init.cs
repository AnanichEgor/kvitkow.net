using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AddressDbId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AddressDbId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    UserInfoDbId = table.Column<string>(nullable: true),
                    Free = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TicketDbId = table.Column<string>(nullable: false),
                    LocationEventAddressDbId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    AdditionalData = table.Column<string>(nullable: true),
                    SellerPhone = table.Column<string>(nullable: true),
                    SellerAdressAddressDbId = table.Column<string>(nullable: true),
                    PaymentSystems = table.Column<string>(nullable: true),
                    TimeActual = table.Column<string>(nullable: true),
                    TypeEvent = table.Column<int>(nullable: false),
                    EventLink = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketDbId);
                    table.ForeignKey(
                        name: "FK_Tickets_Adresses_LocationEventAddressDbId",
                        column: x => x.LocationEventAddressDbId,
                        principalTable: "Adresses",
                        principalColumn: "AddressDbId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Adresses_SellerAdressAddressDbId",
                        column: x => x.SellerAdressAddressDbId,
                        principalTable: "Adresses",
                        principalColumn: "AddressDbId",
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
                        principalColumn: "TicketDbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocationEventAddressDbId",
                table: "Tickets",
                column: "LocationEventAddressDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SellerAdressAddressDbId",
                table: "Tickets",
                column: "SellerAdressAddressDbId");

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
                name: "FK_Tickets_Adresses_LocationEventAddressDbId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Adresses_SellerAdressAddressDbId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserInfos_UserInfoDbId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
