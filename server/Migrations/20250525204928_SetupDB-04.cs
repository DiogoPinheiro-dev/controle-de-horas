using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto_Tarefa");

            migrationBuilder.DropTable(
                name: "Recurso_Apontamento");

            migrationBuilder.DropTable(
                name: "Recurso_SubTarefa");

            migrationBuilder.DropColumn(
                name: "DataIni",
                table: "SubTarefas");

            migrationBuilder.RenameColumn(
                name: "DescricaoSubTarefa",
                table: "SubTarefas",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "DataIni",
                table: "Projetos",
                newName: "DataInicio");

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

            migrationBuilder.AlterColumn<int>(
                name: "DataFim",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataInicio",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
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
                name: "IX_Projetos_RecursoId",
                table: "Projetos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoId",
                table: "Apontamentos",
                column: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos",
                column: "RecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Recursos_RecursoId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_RecursoId",
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
                name: "IX_Projetos_RecursoId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Apontamentos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "SubTarefas",
                newName: "DescricaoSubTarefa");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Projetos",
                newName: "DataIni");

            migrationBuilder.AlterColumn<string>(
                name: "DataFim",
                table: "SubTarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DataIni",
                table: "SubTarefas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projeto_Tarefa",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto_Tarefa", x => new { x.ProjetoId, x.TarefaId });
                    table.ForeignKey(
                        name: "FK_Projeto_Tarefa_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projeto_Tarefa_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recurso_Apontamento",
                columns: table => new
                {
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    ApontamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso_Apontamento", x => new { x.RecursoId, x.ApontamentoId });
                    table.ForeignKey(
                        name: "FK_Recurso_Apontamento_Apontamentos_ApontamentoId",
                        column: x => x.ApontamentoId,
                        principalTable: "Apontamentos",
                        principalColumn: "ApontamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recurso_Apontamento_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recurso_SubTarefa",
                columns: table => new
                {
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    SubTarefaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso_SubTarefa", x => new { x.RecursoId, x.SubTarefaId });
                    table.ForeignKey(
                        name: "FK_Recurso_SubTarefa_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recurso_SubTarefa_SubTarefas_SubTarefaId",
                        column: x => x.SubTarefaId,
                        principalTable: "SubTarefas",
                        principalColumn: "SubTarefaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_Tarefa_TarefaId",
                table: "Projeto_Tarefa",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_Apontamento_ApontamentoId",
                table: "Recurso_Apontamento",
                column: "ApontamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_SubTarefa_SubTarefaId",
                table: "Recurso_SubTarefa",
                column: "SubTarefaId");
        }
    }
}
