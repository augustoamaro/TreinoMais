using Microsoft.EntityFrameworkCore.Migrations;

namespace TreinoMais.AcessoDados.Migrations
{
    public partial class correcoesAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Administradores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Administradores",
                nullable: false,
                defaultValue: "");
        }
    }
}
