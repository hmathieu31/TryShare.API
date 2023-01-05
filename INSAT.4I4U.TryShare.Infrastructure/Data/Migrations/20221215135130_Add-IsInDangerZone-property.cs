using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INSAT._4I4U.TryShare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsInDangerZoneproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInDangerZone",
                table: "Tricycles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInDangerZone",
                table: "Tricycles");
        }
    }
}
