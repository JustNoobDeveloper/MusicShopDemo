using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Migrations
{
    public partial class RestoreOriDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MusicName = table.Column<string>(nullable: true),
                    ArtistName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_GenreID",
                table: "Music",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
