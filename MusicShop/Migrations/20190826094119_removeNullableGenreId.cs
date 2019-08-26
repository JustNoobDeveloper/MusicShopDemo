using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Migrations
{
    public partial class removeNullableGenreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Genre_GenreID",
                table: "Music");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Music",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Music_GenreID",
                table: "Music",
                newName: "IX_Music_GenreId");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Music",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Genre_GenreId",
                table: "Music",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Genre_GenreId",
                table: "Music");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Music",
                newName: "GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Music_GenreId",
                table: "Music",
                newName: "IX_Music_GenreID");

            migrationBuilder.AlterColumn<int>(
                name: "GenreID",
                table: "Music",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Genre_GenreID",
                table: "Music",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
