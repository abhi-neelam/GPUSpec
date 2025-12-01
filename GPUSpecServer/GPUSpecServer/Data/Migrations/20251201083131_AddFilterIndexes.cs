using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUSpecServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFilterIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "memory_type",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "manufacturer",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "generation",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "architecture",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_architecture",
                table: "Listings",
                column: "architecture");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_generation",
                table: "Listings",
                column: "generation");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_manufacturer",
                table: "Listings",
                column: "manufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_memory_size",
                table: "Listings",
                column: "memory_size");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_memory_type",
                table: "Listings",
                column: "memory_type");

            migrationBuilder.CreateIndex(
                name: "IX_Chips_process_size",
                table: "Chips",
                column: "process_size");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Listings_architecture",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_generation",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_manufacturer",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_memory_size",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_memory_type",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Chips_process_size",
                table: "Chips");

            migrationBuilder.AlterColumn<string>(
                name: "memory_type",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "manufacturer",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "generation",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "architecture",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
