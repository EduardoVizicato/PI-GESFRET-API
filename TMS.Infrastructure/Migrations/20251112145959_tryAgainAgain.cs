using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tryAgainAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndData",
                table: "Travels",
                newName: "EndDate");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId1",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Travels_VehicleId1",
                table: "Travels",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Vehicles_VehicleId1",
                table: "Travels",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Vehicles_VehicleId1",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_VehicleId1",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Travels",
                newName: "EndData");
        }
    }
}
