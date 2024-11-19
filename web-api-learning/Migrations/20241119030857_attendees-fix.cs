using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_learning.Migrations
{
    /// <inheritdoc />
    public partial class attendeesfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Attendees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "Attendees",
                type: "bigint",
                nullable: true);
        }
    }
}
