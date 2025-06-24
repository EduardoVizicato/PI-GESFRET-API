using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Travels_TravelId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Loads_LoadId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_LoadId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "LoadId",
                table: "Travels");

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelId",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TravelId1",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_TravelId1",
                table: "Adresses",
                column: "TravelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Travels_TravelId",
                table: "Adresses",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Travels_TravelId1",
                table: "Adresses",
                column: "TravelId1",
                principalTable: "Travels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Travels_TravelId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Travels_TravelId1",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_TravelId1",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "TravelId1",
                table: "Adresses");

            migrationBuilder.AddColumn<Guid>(
                name: "LoadId",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TravelId",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_LoadId",
                table: "Travels",
                column: "LoadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Travels_TravelId",
                table: "Adresses",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Loads_LoadId",
                table: "Travels",
                column: "LoadId",
                principalTable: "Loads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
