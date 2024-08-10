using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MemeGame.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FIleMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Memes");

            migrationBuilder.AddColumn<int>(
                name: "FileMetadataId",
                table: "Memes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FilesMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    IdInExternalStorage = table.Column<string>(type: "text", nullable: false),
                    ExternalStorage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesMetadata", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memes_FileMetadataId",
                table: "Memes",
                column: "FileMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memes_FilesMetadata_FileMetadataId",
                table: "Memes",
                column: "FileMetadataId",
                principalTable: "FilesMetadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memes_FilesMetadata_FileMetadataId",
                table: "Memes");

            migrationBuilder.DropTable(
                name: "FilesMetadata");

            migrationBuilder.DropIndex(
                name: "IX_Memes_FileMetadataId",
                table: "Memes");

            migrationBuilder.DropColumn(
                name: "FileMetadataId",
                table: "Memes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Memes",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Memes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
