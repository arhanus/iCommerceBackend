using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGEFExample.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImagePathFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_path",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "Products",
                type: "text",
                nullable: true);
        }
    }
}
