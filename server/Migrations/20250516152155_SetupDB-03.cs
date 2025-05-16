using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail_ClienteId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_GerenteEmail_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaEmail_AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorEmail_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorEmail_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_AnalistaEmail_AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_GerenteEmail_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "CoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdTarefa",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "AnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "GerenteEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ProjetoEmailCliente",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjetoEmailGerente",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecursoEmail",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TarefaEmailCoordenador",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoSubTarefa",
                table: "SubTarefas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubTarefaId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RecursoEmail",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecursoId",
                table: "Recursos",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Recursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailGerente",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailCliente",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClienteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Projeto",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecursoEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecursoId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Empresas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecursoEmail",
                table: "Apontamentos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorasFinalizadas",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HorasApontadas",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApontamentoId",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "SubTarefaId",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas",
                column: "SubTarefaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                columns: new[] { "ProjetoId", "EmailCliente", "EmailGerente" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas",
                columns: new[] { "ProjetoId", "ProjetoEmailCliente", "ProjetoEmailGerente" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_RecursoEmail_RecursoId",
                table: "Tarefas",
                columns: new[] { "RecursoEmail", "RecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_RecursoEmail_RecursoId",
                table: "SubTarefas",
                columns: new[] { "RecursoEmail", "RecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_EmpresaId",
                table: "Recursos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_EmpresaId",
                table: "Projeto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_RecursoEmail_RecursoId",
                table: "Projeto",
                columns: new[] { "RecursoEmail", "RecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos",
                column: "SubTarefaId",
                principalTable: "SubTarefas",
                principalColumn: "SubTarefaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail_ClienteId",
                table: "Projeto",
                columns: new[] { "ClienteEmail", "ClienteId" },
                principalTable: "Clientes",
                principalColumns: new[] { "Email", "ClienteId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Empresas_EmpresaId",
                table: "Projeto",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Recursos_RecursoEmail_RecursoId",
                table: "Projeto",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Empresas_EmpresaId",
                table: "Recursos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_RecursoEmail_RecursoId",
                table: "SubTarefas",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas",
                columns: new[] { "TarefaEmailCoordenador", "TarefaId" },
                principalTable: "Tarefas",
                principalColumns: new[] { "EmailCoordenador", "TarefaId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas",
                columns: new[] { "ProjetoId", "ProjetoEmailCliente", "ProjetoEmailGerente" },
                principalTable: "Projeto",
                principalColumns: new[] { "ProjetoId", "EmailCliente", "EmailGerente" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_RecursoEmail_RecursoId",
                table: "Tarefas",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_SubTarefas_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail_ClienteId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Empresas_EmpresaId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_RecursoEmail_RecursoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Empresas_EmpresaId",
                table: "Recursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_RecursoEmail_RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_RecursoEmail_RecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_RecursoEmail_RecursoId",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_RecursoEmail_RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_EmpresaId",
                table: "Recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_EmpresaId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_RecursoEmail_RecursoId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "ProjetoEmailCliente",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "RecursoEmail",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "RecursoEmail",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "RecursoEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "SubTarefaId",
                table: "Apontamentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjetoId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "TarefaId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CoordenadorEmail",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoordenadorRecursoId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TarefaId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TarefaEmailCoordenador",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoSubTarefa",
                table: "SubTarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubTarefaId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTarefa",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AnalistaEmail",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AnalistaRecursoId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServicoId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecursoId",
                table: "Recursos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailGerente",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailCliente",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjetoId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "GerenteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GerenteRecursoId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RecursoEmail",
                table: "Apontamentos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "HorasFinalizadas",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HorasApontadas",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApontamentoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas",
                columns: new[] { "IdTarefa", "SubTarefaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorEmail_CoordenadorRecursoId",
                table: "Tarefas",
                columns: new[] { "CoordenadorEmail", "CoordenadorRecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_AnalistaEmail_AnalistaRecursoId",
                table: "SubTarefas",
                columns: new[] { "AnalistaEmail", "AnalistaRecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GerenteEmail_GerenteRecursoId",
                table: "Projeto",
                columns: new[] { "GerenteEmail", "GerenteRecursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail_ClienteId",
                table: "Projeto",
                columns: new[] { "ClienteEmail", "ClienteId" },
                principalTable: "Clientes",
                principalColumns: new[] { "Email", "ClienteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Recursos_GerenteEmail_GerenteRecursoId",
                table: "Projeto",
                columns: new[] { "GerenteEmail", "GerenteRecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaEmail_AnalistaRecursoId",
                table: "SubTarefas",
                columns: new[] { "AnalistaEmail", "AnalistaRecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas",
                columns: new[] { "TarefaEmailCoordenador", "TarefaId" },
                principalTable: "Tarefas",
                principalColumns: new[] { "EmailCoordenador", "TarefaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorEmail_CoordenadorRecursoId",
                table: "Tarefas",
                columns: new[] { "CoordenadorEmail", "CoordenadorRecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" });
        }
    }
}
