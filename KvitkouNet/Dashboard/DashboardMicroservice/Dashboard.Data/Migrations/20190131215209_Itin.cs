using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Data.Migrations
{
    public partial class Itin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    TypeEvent = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EventLink = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserInfoDbId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserInfoDbId);
                    table.ForeignKey(
                        name: "FK_User_News_UserInfoDbId",
                        column: x => x.UserInfoDbId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocationEvent = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SellerPhone = table.Column<string>(nullable: true),
                    EventLink = table.Column<string>(nullable: true),
                    UserInfoDbId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_News_TicketId",
                        column: x => x.TicketId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_User_UserInfoDbId",
                        column: x => x.UserInfoDbId,
                        principalTable: "User",
                        principalColumn: "UserInfoDbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserInfoDbId",
                table: "Ticket",
                column: "UserInfoDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
