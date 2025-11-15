using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnterpriseRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseId",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Travels_EnterpriseId",
                table: "Travels",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnterpriseId",
                table: "AspNetUsers",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enterprises_EnterpriseId",
                table: "AspNetUsers",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Enterprises_EnterpriseId",
                table: "Travels",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enterprises_EnterpriseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Enterprises_EnterpriseId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Travels_EnterpriseId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EnterpriseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnterpriseId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Enterprises_EnterpriseId",
                table: "Vehicles",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id");
        }
    }
}
