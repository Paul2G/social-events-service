using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wep_api_learning.Migrations
{
    /// <inheritdoc />
    public partial class changeidtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocialEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SocialEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
