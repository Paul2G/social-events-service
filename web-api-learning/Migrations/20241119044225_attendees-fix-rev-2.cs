using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_learning.Migrations
{
    /// <inheritdoc />
    public partial class attendeesfixrev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attendees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attendees");
        }
    }
}
