using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Setup_DB_V2 : Migration
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
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.RecursoId);
                    table.CheckConstraint("CK_Tipo", "Tipo IN ('A', 'G', 'C')");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaClientes",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaClientes", x => new { x.EmpresaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_EmpresaClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaClientes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaRecursos",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaRecursos", x => new { x.EmpresaId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_EmpresaRecursos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaRecursos_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DataInicio = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    DataFim = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaServicos",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServicos", x => new { x.EmpresaId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_EmpresaServicos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataInicio = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    DataFim = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubTarefas",
                columns: table => new
                {
                    SubTarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataInicio = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    DataFim = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTarefas", x => x.SubTarefaId);
                    table.ForeignKey(
                        name: "FK_SubTarefas_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubTarefas_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apontamentos",
                columns: table => new
                {
                    ApontamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OS = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HorasApontadas = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    HorasFinalizadas = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    DataInicio = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    DataFim = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    SubTarefaId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apontamentos", x => x.ApontamentoId);
                    table.ForeignKey(
                        name: "FK_Apontamentos_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "RecursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                        column: x => x.SubTarefaId,
                        principalTable: "SubTarefas",
                        principalColumn: "SubTarefaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoId",
                table: "Apontamentos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaClientes_ClienteId",
                table: "EmpresaClientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaRecursos_RecursoId",
                table: "EmpresaRecursos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServicos_ServicoId",
                table: "EmpresaServicos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_EmpresaId",
                table: "Projetos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_RecursoId",
                table: "Projetos",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_RecursoId",
                table: "SubTarefas",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_RecursoId",
                table: "Tarefas",
                column: "RecursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apontamentos");

            migrationBuilder.DropTable(
                name: "EmpresaClientes");

            migrationBuilder.DropTable(
                name: "EmpresaRecursos");

            migrationBuilder.DropTable(
                name: "EmpresaServicos");

            migrationBuilder.DropTable(
                name: "SubTarefas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Recursos");
        }
    }
}
