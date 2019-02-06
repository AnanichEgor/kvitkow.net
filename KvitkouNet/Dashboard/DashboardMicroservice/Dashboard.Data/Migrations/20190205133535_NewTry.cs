using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Data.Migrations
{
    public partial class NewTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_News_NewsDbNewsId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_User_News_NewsDbNewsId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_News_UserInfoDbId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NewsDbNewsId",
                table: "User",
                newName: "NewsDbsNewsId");

            migrationBuilder.RenameColumn(
                name: "UserInfoDbId",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_NewsDbNewsId",
                table: "User",
                newName: "IX_User_NewsDbsNewsId");

            migrationBuilder.RenameColumn(
                name: "NewsDbNewsId",
                table: "Ticket",
                newName: "NewsDbsNewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_NewsDbNewsId",
                table: "Ticket",
                newName: "IX_Ticket_NewsDbsNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_News_NewsDbsNewsId",
                table: "Ticket",
                column: "NewsDbsNewsId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_News_NewsDbsNewsId",
                table: "User",
                column: "NewsDbsNewsId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_News_UserId",
                table: "User",
                column: "UserId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_News_NewsDbsNewsId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_User_News_NewsDbsNewsId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_News_UserId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NewsDbsNewsId",
                table: "User",
                newName: "NewsDbNewsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "UserInfoDbId");

            migrationBuilder.RenameIndex(
                name: "IX_User_NewsDbsNewsId",
                table: "User",
                newName: "IX_User_NewsDbNewsId");

            migrationBuilder.RenameColumn(
                name: "NewsDbsNewsId",
                table: "Ticket",
                newName: "NewsDbNewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_NewsDbsNewsId",
                table: "Ticket",
                newName: "IX_Ticket_NewsDbNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_News_NewsDbNewsId",
                table: "Ticket",
                column: "NewsDbNewsId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_News_NewsDbNewsId",
                table: "User",
                column: "NewsDbNewsId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_News_UserInfoDbId",
                table: "User",
                column: "UserInfoDbId",
                principalTable: "News",
                principalColumn: "NewsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
