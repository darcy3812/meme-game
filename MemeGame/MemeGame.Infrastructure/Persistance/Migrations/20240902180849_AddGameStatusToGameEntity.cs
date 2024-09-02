using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddGameStatusToGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameStatus",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameStatus",
                table: "Games");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Games",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
