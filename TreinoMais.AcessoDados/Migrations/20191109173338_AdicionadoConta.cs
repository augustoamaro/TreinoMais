using Microsoft.EntityFrameworkCore.Migrations;

namespace TreinoMais.AcessoDados.Migrations
{
    public partial class AdicionadoConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Professores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Professores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Professores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Professores");
        }
    }
}
