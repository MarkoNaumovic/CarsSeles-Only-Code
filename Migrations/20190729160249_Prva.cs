using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlikaOglasi.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    OglasiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(maxLength: 50, nullable: false),
                    FajlSlike = table.Column<byte[]>(nullable: true),
                    TipFajla = table.Column<string>(maxLength: 20, nullable: true),
                    Marka = table.Column<string>(maxLength: 20, nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    Godiste = table.Column<int>(maxLength: 4, nullable: false),
                    Motor = table.Column<int>(maxLength: 6, nullable: false),
                    Snaga_Ks = table.Column<int>(maxLength: 3, nullable: false),
                    Gorivo = table.Column<string>(maxLength: 10, nullable: false),
                    Karoserija = table.Column<string>(maxLength: 10, nullable: false),
                    Opis = table.Column<string>(maxLength: 100, nullable: false),
                    Cena = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.OglasiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oglasi");
        }
    }
}
