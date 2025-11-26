using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUSpecServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_table_bug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingDTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListingDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    architecture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foundry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    generation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memory_size = table.Column<float>(type: "real", nullable: false),
                    process_size = table.Column<int>(type: "int", nullable: true),
                    product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingDTO", x => x.Id);
                });
        }
    }
}
