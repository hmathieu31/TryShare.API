using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INSAT._4I4U.TryShare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tricycles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastKnownLatitude = table.Column<double>(type: "float", nullable: false),
                    LastKnownLongitude = table.Column<double>(type: "float", nullable: false),
                    BatteryPercentage = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tricycles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tricycles");
        }
    }
}
