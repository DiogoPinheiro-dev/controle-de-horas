using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.RecursoId);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                });

            migrationBuilder.CreateTable(
                name: "Empresa_Cliente",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa_Cliente", x => new { x.EmpresaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_Empresa_Cliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresa_Cliente_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa_Recurso",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa_Recurso", x => new { x.EmpresaId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_Empresa_Recurso_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresa_Recurso_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataIni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerenteRecursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_Projetos_Recursos_GerenteRecursoId",
                        column: x => x.GerenteRecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId");
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordenadorRecursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Recursos_CoordenadorRecursoId",
                        column: x => x.CoordenadorRecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId");
                });

            migrationBuilder.CreateTable(
                name: "Empresa_Servico",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa_Servico", x => new { x.EmpresaId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_Empresa_Servico_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresa_Servico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa_Projeto",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa_Projeto", x => new { x.EmpresaId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_Empresa_Projeto_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresa_Projeto_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeto_Cliente",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto_Cliente", x => new { x.ProjetoId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_Projeto_Cliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projeto_Cliente_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "SubTarefas",
                columns: table => new
                {
                    SubTarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSubTarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataIni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTarefas", x => x.SubTarefaId);
                    table.ForeignKey(
                        name: "FK_SubTarefas_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId");
                });

            migrationBuilder.CreateTable(
                name: "Apontamentos",
                columns: table => new
                {
                    ApontamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorasApontadas = table.Column<int>(type: "int", nullable: false),
                    HorasFinalizadas = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<int>(type: "int", nullable: false),
                    SubTarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apontamentos", x => x.ApontamentoId);
                    table.ForeignKey(
                        name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                        column: x => x.SubTarefaId,
                        principalTable: "SubTarefas",
                        principalColumn: "SubTarefaId");
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

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Cliente_ClienteId",
                table: "Empresa_Cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Projeto_ProjetoId",
                table: "Empresa_Projeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Recurso_RecursoId",
                table: "Empresa_Recurso",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Servico_ServicoId",
                table: "Empresa_Servico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_Cliente_ClienteId",
                table: "Projeto_Cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_Tarefa_TarefaId",
                table: "Projeto_Tarefa",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_GerenteRecursoId",
                table: "Projetos",
                column: "GerenteRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_Apontamento_ApontamentoId",
                table: "Recurso_Apontamento",
                column: "ApontamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_SubTarefa_SubTarefaId",
                table: "Recurso_SubTarefa",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa_Cliente");

            migrationBuilder.DropTable(
                name: "Empresa_Projeto");

            migrationBuilder.DropTable(
                name: "Empresa_Recurso");

            migrationBuilder.DropTable(
                name: "Empresa_Servico");

            migrationBuilder.DropTable(
                name: "Projeto_Cliente");

            migrationBuilder.DropTable(
                name: "Projeto_Tarefa");

            migrationBuilder.DropTable(
                name: "Recurso_Apontamento");

            migrationBuilder.DropTable(
                name: "Recurso_SubTarefa");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Apontamentos");

            migrationBuilder.DropTable(
                name: "SubTarefas");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Recursos");
        }
    }
}
