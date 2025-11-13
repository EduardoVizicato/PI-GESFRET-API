using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingRelationsVehicleTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TruckId",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TruckId",
                table: "Travels",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Vehicles_TruckId",
                table: "Travels",
                column: "TruckId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Vehicles_TruckId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Travels_TruckId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Travels");
        }
    }
}
