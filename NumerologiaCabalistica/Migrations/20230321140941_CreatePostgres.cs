using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NumerologiaCabalistica.WebApi.Migrations
{
    public partial class CreatePostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaNumero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Categoria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaNumero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mes = table.Column<string>(type: "text", nullable: false),
                    MesNumeral = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextoNumerico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextoNumerico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextoNumerico_CategoriaNumero_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaNumero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasDoMesFavoraveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MesId = table.Column<int>(type: "integer", nullable: false),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    DiaFavoravel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasDoMesFavoraveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiasDoMesFavoraveis_Mes_MesId",
                        column: x => x.MesId,
                        principalTable: "Mes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiasDoMesFavoraveis_MesId",
                table: "DiasDoMesFavoraveis",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_TextoNumerico_CategoriaId",
                table: "TextoNumerico",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiasDoMesFavoraveis");

            migrationBuilder.DropTable(
                name: "TextoNumerico");

            migrationBuilder.DropTable(
                name: "Mes");

            migrationBuilder.DropTable(
                name: "CategoriaNumero");
        }
    }
}
