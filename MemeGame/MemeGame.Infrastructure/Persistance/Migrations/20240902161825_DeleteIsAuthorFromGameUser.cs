using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIsAuthorFromGameUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthor",
                table: "GameUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthor",
                table: "GameUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
