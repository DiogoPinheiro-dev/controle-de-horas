using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAnalista",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdGerente",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "IdAnalista",
                table: "Apontamentos");

            migrationBuilder.RenameColumn(
                name: "IdProjeto",
                table: "Tarefas",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "IdCoordenador",
                table: "Tarefas",
                newName: "CoordenadorId");

            migrationBuilder.RenameColumn(
                name: "IdTarefa",
                table: "SubTarefas",
                newName: "TarefaId");

            migrationBuilder.RenameColumn(
                name: "IdSubTarefa",
                table: "Apontamentos",
                newName: "SubTarefaId");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Recursos",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OS",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AnalistaId",
                table: "Apontamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Analista",
                columns: table => new
                {
                    AnalistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecursoId = table.Column<int>(type: "int", nullable: true),
                    SubTarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analista", x => x.AnalistaId);
                    table.ForeignKey(
                        name: "FK_Analista_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId");
                    table.ForeignKey(
                        name: "FK_Analista_SubTarefas_SubTarefaId",
                        column: x => x.SubTarefaId,
                        principalTable: "SubTarefas",
                        principalColumn: "SubTarefaId");
                });

            migrationBuilder.CreateTable(
                name: "ClienteEmpresa",
                columns: table => new
                {
                    ClientesClienteId = table.Column<int>(type: "int", nullable: false),
                    EmpresasEmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEmpresa", x => new { x.ClientesClienteId, x.EmpresasEmpresaId });
                    table.ForeignKey(
                        name: "FK_ClienteEmpresa_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteEmpresa_Empresas_EmpresasEmpresaId",
                        column: x => x.EmpresasEmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coordenador",
                columns: table => new
                {
                    CoordenadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenador", x => x.CoordenadorId);
                    table.ForeignKey(
                        name: "FK_Coordenador_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId");
                });

            migrationBuilder.CreateTable(
                name: "EmpresaServico",
                columns: table => new
                {
                    EmpresasEmpresaId = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServico", x => new { x.EmpresasEmpresaId, x.ServicosServicoId });
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Empresas_EmpresasEmpresaId",
                        column: x => x.EmpresasEmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaServico_Servicos_ServicosServicoId",
                        column: x => x.ServicosServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    GerenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.GerenteId);
                    table.ForeignKey(
                        name: "FK_Gerente_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorId",
                table: "Tarefas",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_GerenteId",
                table: "Projetos",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_AnalistaId",
                table: "Apontamentos",
                column: "AnalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analista_RecursoId",
                table: "Analista",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Analista_SubTarefaId",
                table: "Analista",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEmpresa_EmpresasEmpresaId",
                table: "ClienteEmpresa",
                column: "EmpresasEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordenador_RecursoId",
                table: "Coordenador",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServico_ServicosServicoId",
                table: "EmpresaServico",
                column: "ServicosServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerente_RecursoId",
                table: "Gerente",
                column: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Analista_AnalistaId",
                table: "Apontamentos",
                column: "AnalistaId",
                principalTable: "Analista",
                principalColumn: "AnalistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId",
                principalTable: "SubTarefas",
                principalColumn: "SubTarefaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Gerente_GerenteId",
                table: "Projetos",
                column: "GerenteId",
                principalTable: "Gerente",
                principalColumn: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Coordenador_CoordenadorId",
                table: "Tarefas",
                column: "CoordenadorId",
                principalTable: "Coordenador",
                principalColumn: "CoordenadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Analista_AnalistaId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Gerente_GerenteId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Coordenador_CoordenadorId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Analista");

            migrationBuilder.DropTable(
                name: "ClienteEmpresa");

            migrationBuilder.DropTable(
                name: "Coordenador");

            migrationBuilder.DropTable(
                name: "EmpresaServico");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_GerenteId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_AnalistaId",
                table: "Apontamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "AnalistaId",
                table: "Apontamentos");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Tarefas",
                newName: "IdProjeto");

            migrationBuilder.RenameColumn(
                name: "CoordenadorId",
                table: "Tarefas",
                newName: "IdCoordenador");

            migrationBuilder.RenameColumn(
                name: "TarefaId",
                table: "SubTarefas",
                newName: "IdTarefa");

            migrationBuilder.RenameColumn(
                name: "SubTarefaId",
                table: "Apontamentos",
                newName: "IdSubTarefa");

            migrationBuilder.AddColumn<int>(
                name: "IdAnalista",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGerente",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdAnalista",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
