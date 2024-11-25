using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api_learning.Migrations
{
    /// <inheritdoc />
    public partial class roleseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e0e4b37-d2e7-4a64-abc6-7dca951da9df", null, "Admin", "ADMIN" },
                    { "c282b1a5-5935-4d3c-8b29-50c7e3e56e49", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e0e4b37-d2e7-4a64-abc6-7dca951da9df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c282b1a5-5935-4d3c-8b29-50c7e3e56e49");
        }
    }
}
