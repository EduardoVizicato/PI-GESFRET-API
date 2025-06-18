using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestingNewLoadEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_AspNetUsers_UserId",
                table: "Loads");

            migrationBuilder.AddColumn<Guid>(
                name: "UserModelId",
                table: "Loads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loads_UserModelId",
                table: "Loads",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_AspNetUsers_UserId",
                table: "Loads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_AspNetUsers_UserModelId",
                table: "Loads",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_AspNetUsers_UserId",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_AspNetUsers_UserModelId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_UserModelId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Loads");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_AspNetUsers_UserId",
                table: "Loads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
