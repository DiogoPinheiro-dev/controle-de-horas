using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Recursos_RecursoId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_RecursoId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.AddColumn<int>(
                name: "IdCoordenador",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProjeto",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAnalista",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTarefa",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdGerente",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAnalista",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSubTarefa",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCoordenador",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdProjeto",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdAnalista",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdTarefa",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdGerente",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "IdAnalista",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "IdSubTarefa",
                table: "Apontamentos");

            migrationBuilder.AddColumn<int>(
                name: "CoordenadorRecursoId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "SubTarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "SubTarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTarefaId",
                table: "Apontamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_RecursoId",
                table: "SubTarefas",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_RecursoId",
                table: "Projetos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoId",
                table: "Apontamentos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos",
                column: "RecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId",
                principalTable: "SubTarefas",
                principalColumn: "SubTarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Recursos_RecursoId",
                table: "Projetos",
                column: "RecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_RecursoId",
                table: "SubTarefas",
                column: "RecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");
        }
    }
}
