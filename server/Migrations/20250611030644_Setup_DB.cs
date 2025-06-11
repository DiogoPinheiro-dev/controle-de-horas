using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Setup_DB : Migration
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
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => new { x.ClienteId, x.Email });
                    table.CheckConstraint("CK_Email", "Email LIKE '%@gmail.com%'");
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => new { x.EmpresaId, x.Email });
                    table.CheckConstraint("CK_Email1", "Email LIKE '%@gmail.com%'");
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    RecursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => new { x.RecursoId, x.Email });
                    table.CheckConstraint("CK_Email2", "Email LIKE '%@gmail.com%'");
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
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelDeUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => new { x.UsuarioId, x.Email });
                    table.CheckConstraint("CK_Email3", "Email LIKE '%@gmail.com%'");
                });

            migrationBuilder.CreateTable(
                name: "EmpresaClientes",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaClientes", x => new { x.EmpresaId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_EmpresaClientes_Clientes_ClienteId_ClienteEmail",
                        columns: x => new { x.ClienteId, x.ClienteEmail },
                        principalTable: "Clientes",
                        principalColumns: new[] { "ClienteId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaClientes_Empresas_EmpresaId_EmpresaEmail",
                        columns: x => new { x.EmpresaId, x.EmpresaEmail },
                        principalTable: "Empresas",
                        principalColumns: new[] { "EmpresaId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaRecursos",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaRecursos", x => new { x.EmpresaId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_EmpresaRecursos_Empresas_EmpresaId_EmpresaEmail",
                        columns: x => new { x.EmpresaId, x.EmpresaEmail },
                        principalTable: "Empresas",
                        principalColumns: new[] { "EmpresaId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaRecursos_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
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
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteId_ClienteEmail",
                        columns: x => new { x.ClienteId, x.ClienteEmail },
                        principalTable: "Clientes",
                        principalColumns: new[] { "ClienteId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Empresas_EmpresaId_EmpresaEmail",
                        columns: x => new { x.EmpresaId, x.EmpresaEmail },
                        principalTable: "Empresas",
                        principalColumns: new[] { "EmpresaId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaServicos",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServicos", x => new { x.EmpresaId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_EmpresaServicos_Empresas_EmpresaId_EmpresaEmail",
                        columns: x => new { x.EmpresaId, x.EmpresaEmail },
                        principalTable: "Empresas",
                        principalColumns: new[] { "EmpresaId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosClientes",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosClientes", x => new { x.UsuarioId, x.ClienteId });
                    table.ForeignKey(
                        name: "FK_UsuariosClientes_Clientes_ClienteId_ClienteEmail",
                        columns: x => new { x.ClienteId, x.ClienteEmail },
                        principalTable: "Clientes",
                        principalColumns: new[] { "ClienteId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosClientes_Usuarios_UsuarioId_UsuarioEmail",
                        columns: x => new { x.UsuarioId, x.UsuarioEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "UsuarioId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosEmpresas",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosEmpresas", x => new { x.UsuarioId, x.EmpresaId });
                    table.ForeignKey(
                        name: "FK_UsuariosEmpresas_Empresas_EmpresaId_EmpresaEmail",
                        columns: x => new { x.EmpresaId, x.EmpresaEmail },
                        principalTable: "Empresas",
                        principalColumns: new[] { "EmpresaId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosEmpresas_Usuarios_UsuarioId_UsuarioEmail",
                        columns: x => new { x.UsuarioId, x.UsuarioEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "UsuarioId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosRecursos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRecursos", x => new { x.UsuarioId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_UsuariosRecursos_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosRecursos_Usuarios_UsuarioId_UsuarioEmail",
                        columns: x => new { x.UsuarioId, x.UsuarioEmail },
                        principalTable: "Usuarios",
                        principalColumns: new[] { "UsuarioId", "Email" },
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
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_Tarefas_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
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
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTarefas", x => x.SubTarefaId);
                    table.ForeignKey(
                        name: "FK_SubTarefas_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
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
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    RecursoEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apontamentos", x => x.ApontamentoId);
                    table.ForeignKey(
                        name: "FK_Apontamentos_Recursos_RecursoId_RecursoEmail",
                        columns: x => new { x.RecursoId, x.RecursoEmail },
                        principalTable: "Recursos",
                        principalColumns: new[] { "RecursoId", "Email" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                        column: x => x.SubTarefaId,
                        principalTable: "SubTarefas",
                        principalColumn: "SubTarefaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoId_RecursoEmail",
                table: "Apontamentos",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaClientes_ClienteId_ClienteEmail",
                table: "EmpresaClientes",
                columns: new[] { "ClienteId", "ClienteEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaClientes_EmpresaId_EmpresaEmail",
                table: "EmpresaClientes",
                columns: new[] { "EmpresaId", "EmpresaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaRecursos_EmpresaId_EmpresaEmail",
                table: "EmpresaRecursos",
                columns: new[] { "EmpresaId", "EmpresaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaRecursos_RecursoId_RecursoEmail",
                table: "EmpresaRecursos",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServicos_EmpresaId_EmpresaEmail",
                table: "EmpresaServicos",
                columns: new[] { "EmpresaId", "EmpresaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServicos_ServicoId",
                table: "EmpresaServicos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteId_ClienteEmail",
                table: "Projetos",
                columns: new[] { "ClienteId", "ClienteEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_EmpresaId_EmpresaEmail",
                table: "Projetos",
                columns: new[] { "EmpresaId", "EmpresaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_RecursoId_RecursoEmail",
                table: "Projetos",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_RecursoId_RecursoEmail",
                table: "SubTarefas",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_RecursoId_RecursoEmail",
                table: "Tarefas",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_ClienteId_ClienteEmail",
                table: "UsuariosClientes",
                columns: new[] { "ClienteId", "ClienteEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_UsuarioId_UsuarioEmail",
                table: "UsuariosClientes",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEmpresas_EmpresaId_EmpresaEmail",
                table: "UsuariosEmpresas",
                columns: new[] { "EmpresaId", "EmpresaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEmpresas_UsuarioId_UsuarioEmail",
                table: "UsuariosEmpresas",
                columns: new[] { "UsuarioId", "UsuarioEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRecursos_RecursoId_RecursoEmail",
                table: "UsuariosRecursos",
                columns: new[] { "RecursoId", "RecursoEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRecursos_UsuarioId_UsuarioEmail",
                table: "UsuariosRecursos",
                columns: new[] { "UsuarioId", "UsuarioEmail" });
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
                name: "UsuariosClientes");

            migrationBuilder.DropTable(
                name: "UsuariosEmpresas");

            migrationBuilder.DropTable(
                name: "UsuariosRecursos");

            migrationBuilder.DropTable(
                name: "SubTarefas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Usuarios");

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
