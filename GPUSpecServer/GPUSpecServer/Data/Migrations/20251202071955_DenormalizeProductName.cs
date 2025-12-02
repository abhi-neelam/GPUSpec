using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUSpecServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class DenormalizeProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_product_name",
                table: "Listings",
                column: "product_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Listings_product_name",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "product_name",
                table: "Listings");
        }
    }
}
