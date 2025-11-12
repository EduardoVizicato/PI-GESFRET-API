using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationshipInTravelAndVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Travels_VehicleId",
                table: "Travels",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Vehicles_VehicleId",
                table: "Travels",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Vehicles_VehicleId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_VehicleId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Travels");
        }
    }
}
