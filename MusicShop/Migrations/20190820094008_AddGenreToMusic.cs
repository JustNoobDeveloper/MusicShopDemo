using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Migrations
{
    public partial class AddGenreToMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Music",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Music_GenreID",
                table: "Music",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Genre_GenreID",
                table: "Music",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Genre_GenreID",
                table: "Music");

            migrationBuilder.DropIndex(
                name: "IX_Music_GenreID",
                table: "Music");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Music");
        }
    }
}
