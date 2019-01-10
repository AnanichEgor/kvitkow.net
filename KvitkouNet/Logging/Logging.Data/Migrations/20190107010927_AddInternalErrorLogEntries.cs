using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logging.Data.Migrations
{
    public partial class AddInternalErrorLogEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalErrorLogEntries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    HResult = table.Column<int>(nullable: false),
                    InnerExceptionString = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    TargetSiteName = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalErrorLogEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalErrorLogEntries");
        }
    }
}
