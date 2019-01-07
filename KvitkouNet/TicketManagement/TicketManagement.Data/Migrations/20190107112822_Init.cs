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
                    AddressId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Flat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    UserInfoId = table.Column<string>(nullable: true),
                    Free = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TicketId = table.Column<string>(nullable: false),
                    LocationEventAddressId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    AdditionalData = table.Column<string>(nullable: true),
                    SellerPhone = table.Column<string>(nullable: true),
                    SellerAdressAddressId = table.Column<string>(nullable: true),
                    PaymentSystems = table.Column<string>(nullable: true),
                    TimeActual = table.Column<string>(nullable: true),
                    TypeEvent = table.Column<int>(nullable: false),
                    EventLink = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Adresses_LocationEventAddressId",
                        column: x => x.LocationEventAddressId,
                        principalTable: "Adresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Adresses_SellerAdressAddressId",
                        column: x => x.SellerAdressAddressId,
                        principalTable: "Adresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserInfoId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    TicketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserInfoId);
                    table.ForeignKey(
                        name: "FK_UserInfos_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocationEventAddressId",
                table: "Tickets",
                column: "LocationEventAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SellerAdressAddressId",
                table: "Tickets",
                column: "SellerAdressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserInfoId",
                table: "Tickets",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_TicketId",
                table: "UserInfos",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_UserInfos_UserInfoId",
                table: "Tickets",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "UserInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Adresses_LocationEventAddressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Adresses_SellerAdressAddressId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UserInfos_UserInfoId",
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
