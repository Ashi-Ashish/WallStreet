using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CommentToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0294543d-9820-49fb-9f26-221b2db6b0cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19131682-31a2-450d-8c2b-d906d1f2f32c");

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

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2dea90b-b1fc-40bd-83b5-b8a842fe6fbd", null, "User", "USER" },
                    { "a42da05b-41d4-4b53-a57a-24f3210a780c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2dea90b-b1fc-40bd-83b5-b8a842fe6fbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a42da05b-41d4-4b53-a57a-24f3210a780c");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0294543d-9820-49fb-9f26-221b2db6b0cd", null, "User", "USER" },
                    { "19131682-31a2-450d-8c2b-d906d1f2f32c", null, "Admin", "ADMIN" }
                });

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
    }
}
