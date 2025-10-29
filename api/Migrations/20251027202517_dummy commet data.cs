using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class dummycommetdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Apple posted another record quarter. Holding long-term.", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Strong Q2 Results" },
                    { 2, "Azure growth surprised to the upside; adding to my MSFT position.", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cloud Keeps Growing" },
                    { 3, "Amazon retail margins are tight, but AWS remains a cash cow.", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Competition Heating Up" },
                    { 4, "Tesla still feels pricey—waiting for a pullback before buying more.", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Valuation Check" },
                    { 5, "NVIDIA guidance keeps climbing; bullish on continued GPU demand.", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "AI Tailwinds" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
