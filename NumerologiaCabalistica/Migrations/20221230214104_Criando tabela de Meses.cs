using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumerologiaCabalistica.Migrations
{
    public partial class CriandotabeladeMeses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mes",
                table: "DiasDoMesFavoraveis");

            migrationBuilder.AddColumn<int>(
                name: "MesId",
                table: "DiasDoMesFavoraveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiasDoMesFavoraveis_MesId",
                table: "DiasDoMesFavoraveis",
                column: "MesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiasDoMesFavoraveis_Mes_MesId",
                table: "DiasDoMesFavoraveis",
                column: "MesId",
                principalTable: "Mes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiasDoMesFavoraveis_Mes_MesId",
                table: "DiasDoMesFavoraveis");

            migrationBuilder.DropTable(
                name: "Mes");

            migrationBuilder.DropIndex(
                name: "IX_DiasDoMesFavoraveis_MesId",
                table: "DiasDoMesFavoraveis");

            migrationBuilder.DropColumn(
                name: "MesId",
                table: "DiasDoMesFavoraveis");

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "DiasDoMesFavoraveis",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
