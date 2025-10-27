using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUSpecServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    foundry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    process_size = table.Column<int>(type: "int", nullable: true),
                    transistors = table.Column<int>(type: "int", nullable: true),
                    density = table.Column<float>(type: "real", nullable: true),
                    die_size = table.Column<int>(type: "int", nullable: true),
                    chip_package = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    directx_major_version = table.Column<int>(type: "int", nullable: true),
                    directx_minor_version = table.Column<int>(type: "int", nullable: true),
                    opengl_major_version = table.Column<int>(type: "int", nullable: true),
                    opengl_minor_version = table.Column<int>(type: "int", nullable: true),
                    vulkan_major_version = table.Column<int>(type: "int", nullable: true),
                    vulkan_minor_version = table.Column<int>(type: "int", nullable: true),
                    opencl_major_version = table.Column<int>(type: "int", nullable: true),
                    opencl_minor_version = table.Column<int>(type: "int", nullable: true),
                    cuda_major_version = table.Column<int>(type: "int", nullable: true),
                    cuda_minor_version = table.Column<int>(type: "int", nullable: true),
                    shader_model_major_version = table.Column<int>(type: "int", nullable: true),
                    shader_model_minor_version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tensor_cores = table.Column<int>(type: "int", nullable: false),
                    rt_cores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    architecture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    generation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_clock = table.Column<int>(type: "int", nullable: false),
                    boost_clock = table.Column<int>(type: "int", nullable: false),
                    memory_clock = table.Column<int>(type: "int", nullable: true),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true),
                    bus_interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    memory_size = table.Column<float>(type: "real", nullable: false),
                    memory_bus = table.Column<int>(type: "int", nullable: true),
                    memory_bandwidth = table.Column<float>(type: "real", nullable: true),
                    memory_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shading_units = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tmus = table.Column<int>(type: "int", nullable: false),
                    rops = table.Column<int>(type: "int", nullable: false),
                    smus = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    l1_cache = table.Column<float>(type: "real", nullable: false),
                    l2_cache = table.Column<float>(type: "real", nullable: false),
                    tdp = table.Column<int>(type: "int", nullable: true),
                    board_length = table.Column<int>(type: "int", nullable: true),
                    board_width = table.Column<int>(type: "int", nullable: true),
                    board_slot_width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suggested_psu = table.Column<int>(type: "int", nullable: true),
                    power_connectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    display_connectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChipId = table.Column<int>(type: "int", nullable: false),
                    pixel_rate = table.Column<float>(type: "real", nullable: false),
                    texture_rate = table.Column<float>(type: "real", nullable: false),
                    fp16 = table.Column<float>(type: "real", nullable: true),
                    fp32 = table.Column<float>(type: "real", nullable: true),
                    fp64 = table.Column<float>(type: "real", nullable: true),
                    tpu_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tpu_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Chips_ChipId",
                        column: x => x.ChipId,
                        principalTable: "Chips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chips_Name",
                table: "Chips",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ChipId",
                table: "Listings",
                column: "ChipId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ProductId",
                table: "Listings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Chips");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
