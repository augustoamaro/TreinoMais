using Microsoft.EntityFrameworkCore.Migrations;

namespace TreinoMais.AcessoDados.Migrations
{
    public partial class ProfessorAdministrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Professores");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_AdministradorId",
                table: "Professores",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Administradores_AdministradorId",
                table: "Professores",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "AdministradorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Administradores_AdministradorId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_AdministradorId",
                table: "Professores");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Professores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Professores",
                nullable: true);
        }
    }
}
