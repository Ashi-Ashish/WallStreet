using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDividend", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.24m, 2500000000000L, 150.00m, "AAPL" },
                    { 2, "Microsoft Corporation", "Technology", 0.62m, 2100000000000L, 280.00m, "MSFT" },
                    { 3, "Amazon.com Inc.", "Consumer Discretionary", 0.00m, 1300000000000L, 125.00m, "AMZN" },
                    { 4, "Tesla Inc.", "Automotive", 0.00m, 900000000000L, 750.00m, "TSLA" },
                    { 5, "NVIDIA Corporation", "Semiconductors", 0.16m, 550000000000L, 220.00m, "NVDA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
