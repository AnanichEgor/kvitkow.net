using Microsoft.EntityFrameworkCore.Migrations;

namespace Notification.Data.Migrations
{
    public partial class addpropertyIsClosedtoNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Notifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Notifications");
        }
    }
}
