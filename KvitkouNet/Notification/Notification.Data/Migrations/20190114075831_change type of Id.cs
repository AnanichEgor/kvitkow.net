using Microsoft.EntityFrameworkCore.Migrations;

namespace Notification.Data.Migrations
{
    public partial class changetypeofId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Notifications",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Notifications",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
