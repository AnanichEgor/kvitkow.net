using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logging.Data.Migrations
{
    public partial class AddAccountLogEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountLogEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    DeviceDescription = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLogEntries");
        }
    }
}
