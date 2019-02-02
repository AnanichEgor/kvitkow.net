using Microsoft.EntityFrameworkCore.Migrations;

namespace UserSettings.Data.Migrations
{
    public partial class addNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationsId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsLikeMyTicket = table.Column<bool>(nullable: false),
                    IsWantBuy = table.Column<bool>(nullable: false),
                    IsOtherNotification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_NotificationsId",
                table: "Profiles",
                column: "NotificationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Notifications_NotificationsId",
                table: "Profiles",
                column: "NotificationsId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Notifications_NotificationsId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_NotificationsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "NotificationsId",
                table: "Profiles");
        }
    }
}
