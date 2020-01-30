using Microsoft.EntityFrameworkCore.Migrations;

namespace SlikaOglasi.Migrations
{
    public partial class addUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipFajla",
                table: "Oglasi");

            migrationBuilder.AlterColumn<string>(
                name: "Naslov",
                table: "Oglasi",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Oglasi",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Kontak",
                columns: table => new
                {
                    Ime = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: false),
                    Poruka = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontak", x => x.Ime);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontak");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Oglasi");

            migrationBuilder.AlterColumn<string>(
                name: "Naslov",
                table: "Oglasi",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "TipFajla",
                table: "Oglasi",
                maxLength: 20,
                nullable: true);
        }
    }
}
