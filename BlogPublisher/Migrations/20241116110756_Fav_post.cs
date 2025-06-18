using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Fav_post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFav",
                table: "Authors");

            migrationBuilder.AddColumn<bool>(
                name: "IsFav",
                table: "Posts",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFav",
                table: "Posts");

            migrationBuilder.AddColumn<bool>(
                name: "IsFav",
                table: "Authors",
                type: "bit",
                nullable: true);
        }
    }
}
