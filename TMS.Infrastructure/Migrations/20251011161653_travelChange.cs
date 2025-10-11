using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class travelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelName",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravelStatus",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Travels",
                newName: "Origin");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "Travels",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "TravelName",
                table: "Travels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TravelStatus",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
