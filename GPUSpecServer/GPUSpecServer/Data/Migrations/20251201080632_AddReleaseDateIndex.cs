using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUSpecServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReleaseDateIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Listings_release_date",
                table: "Listings",
                column: "release_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Listings_release_date",
                table: "Listings");
        }
    }
}
