
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumerologiaCabalistica.Migrations
{
    public partial class Trocadocampodiasfavoraveisparadiafavoravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiasFavoraveis",
                table: "DiasDoMesFavoraveis",
                newName: "DiaFavoravel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaFavoravel",
                table: "DiasDoMesFavoraveis",
                newName: "DiasFavoraveis");
        }
    }
}
