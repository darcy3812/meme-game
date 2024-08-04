using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GameUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_UserId",
                table: "GameUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameUsers_Users_UserId",
                table: "GameUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameUsers_Users_UserId",
                table: "GameUsers");

            migrationBuilder.DropIndex(
                name: "IX_GameUsers_UserId",
                table: "GameUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameUsers");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
