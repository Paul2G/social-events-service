using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_learning.Migrations
{
    /// <inheritdoc />
    public partial class locationmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "SocialEvents");

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "SocialEvents",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialEvents_LocationId",
                table: "SocialEvents",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialEvents_Locations_LocationId",
                table: "SocialEvents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialEvents_Locations_LocationId",
                table: "SocialEvents");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_SocialEvents_LocationId",
                table: "SocialEvents");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "SocialEvents");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SocialEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
