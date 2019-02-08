using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<string>(nullable: false),
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
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocationEvent = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SellerPhone = table.Column<string>(nullable: true),
                    EventLink = table.Column<string>(nullable: true),
                    NewsDbsNewsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_News_NewsDbsNewsId",
                        column: x => x.NewsDbsNewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_News_TicketId",
                        column: x => x.TicketId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    NewsDbsNewsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_News_NewsDbsNewsId",
                        column: x => x.NewsDbsNewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_News_UserId",
                        column: x => x.UserId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_NewsDbsNewsId",
                table: "Ticket",
                column: "NewsDbsNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_NewsDbsNewsId",
                table: "User",
                column: "NewsDbsNewsId");
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
