using Microsoft.EntityFrameworkCore.Migrations;

namespace TreinoMais.AcessoDados.Migrations
{
    public partial class correcaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Alunos_AlunoId",
                table: "Fichas");

            migrationBuilder.DropForeignKey(
                name: "FK_ListasExercicios_Fichas_TreinoId",
                table: "ListasExercicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fichas",
                table: "Fichas");

            migrationBuilder.RenameTable(
                name: "Fichas",
                newName: "Treinos");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_AlunoId",
                table: "Treinos",
                newName: "IX_Treinos_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListasExercicios_Treinos_TreinoId",
                table: "ListasExercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "TreinoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListasExercicios_Treinos_TreinoId",
                table: "ListasExercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos");

            migrationBuilder.RenameTable(
                name: "Treinos",
                newName: "Fichas");

            migrationBuilder.RenameIndex(
                name: "IX_Treinos_AlunoId",
                table: "Fichas",
                newName: "IX_Fichas_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fichas",
                table: "Fichas",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Alunos_AlunoId",
                table: "Fichas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListasExercicios_Fichas_TreinoId",
                table: "ListasExercicios",
                column: "TreinoId",
                principalTable: "Fichas",
                principalColumn: "TreinoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
