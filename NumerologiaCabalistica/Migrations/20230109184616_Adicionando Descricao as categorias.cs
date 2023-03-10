using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumerologiaCabalistica.Migrations
{
    public partial class AdicionandoDescricaoascategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "CategoriaNumero",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "CategoriaNumero");
        }
    }
}
