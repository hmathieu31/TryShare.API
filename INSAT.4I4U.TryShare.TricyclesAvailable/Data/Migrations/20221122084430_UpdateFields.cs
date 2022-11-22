using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Tricycles",
                newName: "LastKnownLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Tricycles",
                newName: "LastKnownLatitude");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Tricycles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Tricycles");

            migrationBuilder.RenameColumn(
                name: "LastKnownLongitude",
                table: "Tricycles",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "LastKnownLatitude",
                table: "Tricycles",
                newName: "Latitude");
        }
    }
}
