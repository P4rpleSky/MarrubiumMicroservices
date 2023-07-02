using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marrubium.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ProductTypes = table.Column<string>(type: "jsonb", nullable: false),
                    Functions = table.Column<string>(type: "jsonb", nullable: false),
                    SkinTypes = table.Column<string>(type: "jsonb", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Functions", "ImageUrl", "Name", "Price", "ProductTypes", "SkinTypes" },
                values: new object[,]
                {
                    { 1, null, "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/1_1.png", "Cream with retinol", 1000, "[\"Lotion\"]", "[\"Soft\"]" },
                    { 2, null, "[\"Rejuvenating\"]", "https://images.bsite.net/products/1_2.png", "Lotion with centella", 1500, "[\"Serum\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 3, null, "[\"Restoring\"]", "https://images.bsite.net/products/1_3.png", "Serum with green tea", 1200, "[\"Serum\"]", "[\"Soft\"]" },
                    { 4, null, "[\"Restoring\"]", "https://images.bsite.net/products/1_4.png", "Serum with wormwood", 1600, "[\"Serum\"]", "[\"Soft\"]" },
                    { 5, null, "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/2_1.png", "Scrub with vanilla", 900, "[\"Cleaning\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 6, null, "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/2_2.png", "Under-eye cream", 2000, "[\"Lotion\"]", "[\"Sensitive\"]" },
                    { 7, null, "[\"Rejuvenating\"]", "https://images.bsite.net/products/2_3.png", "Cream with mint", 1000, "[\"Lotion\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 8, null, "[\"Restoring\"]", "https://images.bsite.net/products/2_4.png", "Clay mask with matcha", 800, "[\"Mask\"]", "[\"Sensitive\"]" },
                    { 9, null, "[\"Restoring\"]", "https://images.bsite.net/products/3_1.png", "The handle of the shovel", 500, "[\"Mask\"]", "[\"Rough\"]" },
                    { 10, null, "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/3_2.png", "Garage", 10000, "[\"Cleaning\"]", "[\"Rough\"]" },
                    { 11, null, "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/3_3.png", "Russian hotdog", 50, "[\"Serum\"]", "[\"Rough\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
