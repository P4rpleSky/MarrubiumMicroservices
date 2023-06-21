using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marrubium.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Functions", "ImageUrl", "Name", "Price", "ProductTypes", "SkinTypes" },
                values: new object[,]
                {
                    { 1, "", "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/1_1.png", "Cream with retinol", 1000, "[\"Lotion\"]", "[\"Soft\"]" },
                    { 2, "", "[\"Rejuvenating\"]", "https://images.bsite.net/products/1_2.png", "Lotion with centella", 1500, "[\"Serum\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 3, "", "[\"Restoring\"]", "https://images.bsite.net/products/1_3.png", "Serum with green tea", 1200, "[\"Serum\"]", "[\"Soft\"]" },
                    { 4, "", "[\"Restoring\"]", "https://images.bsite.net/products/1_4.png", "Serum with wormwood", 1600, "[\"Serum\"]", "[\"Soft\"]" },
                    { 5, "", "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/2_1.png", "Scrub with vanilla", 900, "[\"Cleaning\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 6, "", "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/2_2.png", "Under-eye cream", 2000, "[\"Lotion\"]", "[\"Sensitive\"]" },
                    { 7, "", "[\"Rejuvenating\"]", "https://images.bsite.net/products/2_3.png", "Cream with mint", 1000, "[\"Lotion\"]", "[\"Soft\",\"Sensitive\"]" },
                    { 8, "", "[\"Restoring\"]", "https://images.bsite.net/products/2_4.png", "Clay mask with matcha", 800, "[\"Mask\"]", "[\"Sensitive\"]" },
                    { 9, "", "[\"Restoring\"]", "https://images.bsite.net/products/3_1.png", "The handle of the shovel", 500, "[\"Mask\"]", "[\"Rough\"]" },
                    { 10, "", "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/3_2.png", "Garage", 10000, "[\"Cleaning\"]", "[\"Rough\"]" },
                    { 11, "", "[\"Rejuvenating\",\"Restoring\"]", "https://images.bsite.net/products/3_3.png", "Russian hotdog", 50, "[\"Serum\"]", "[\"Rough\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);
        }
    }
}
