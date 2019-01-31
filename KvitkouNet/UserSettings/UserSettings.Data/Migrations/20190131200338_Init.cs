﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserSettings.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserImage = table.Column<byte[]>(nullable: true),
                    IsPrivateAccount = table.Column<bool>(nullable: false),
                    PreferAddress = table.Column<string>(nullable: true),
                    PreferRegion = table.Column<string>(nullable: true),
                    IsGetTicketInfo = table.Column<bool>(nullable: false),
                    PreferPlace = table.Column<string>(nullable: true),
                    NotificationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_NotificationsId",
                table: "Settings",
                column: "NotificationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
