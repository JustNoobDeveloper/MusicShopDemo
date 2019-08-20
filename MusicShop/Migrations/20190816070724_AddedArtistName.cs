using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Migrations
{
    public partial class AddedArtistName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Music",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Music");
        }
    }
}
