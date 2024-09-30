using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGEFExample.Migrations
{
    /// <inheritdoc />
    public partial class addSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "subcategory",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subcategory",
                table: "Products");
        }
    }
}
