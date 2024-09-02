using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorToGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthor",
                table: "GameUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_AuthorId",
                table: "Games",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_AuthorId",
                table: "Games",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_AuthorId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_AuthorId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IsAuthor",
                table: "GameUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Games");
        }
    }
}
