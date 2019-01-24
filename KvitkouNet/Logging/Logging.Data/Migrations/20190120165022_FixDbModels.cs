using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logging.Data.Migrations
{
    public partial class FixDbModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TicketDealLogEntries");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TicketActionLogEntries");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "SearchQueryLogEntries");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "PaymentLogEntries");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "InternalErrorLogEntries");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "AccountLogEntries");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "TicketActionLogEntries",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "InternalErrorLogEntries",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TicketDealLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TicketDealLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TicketActionLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TicketActionLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "SearchQueryLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SearchQueryLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PaymentLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PaymentLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "InternalErrorLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionType",
                table: "InternalErrorLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AccountLogEntries",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AccountLogEntries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TicketDealLogEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TicketActionLogEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SearchQueryLogEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentLogEntries");

            migrationBuilder.DropColumn(
                name: "ExceptionType",
                table: "InternalErrorLogEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountLogEntries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TicketActionLogEntries",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "InternalErrorLogEntries",
                newName: "TypeName");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TicketDealLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "TicketDealLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TicketActionLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "TicketActionLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SearchQueryLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "SearchQueryLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "PaymentLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "PaymentLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "InternalErrorLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "InternalErrorLogEntries",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AccountLogEntries",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "AccountLogEntries",
                nullable: true);
        }
    }
}
