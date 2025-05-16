using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupDB02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId",
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
                name: "IX_SubTarefas_AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ClienteId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos");

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
                name: "AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Apontamentos");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdProjetoProjetoId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdRecursoCoordenadorEmail",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdRecursoCoordenadorRecursoId",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SubTarefaId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdApontamentoApontamentoId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdApontamentoOS",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdRecursoAnalistaEmail",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdRecursoAnalistaRecursoId",
                table: "SubTarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "Nome",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Recursos",
                type: "nvarchar(450)",
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

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Projeto",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdClienteClienteId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdClienteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdGerenteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdGerenteRecursoId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Empresas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdServicoServicoId",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresaEmpresaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdServicoServicoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Apontamentos",
                type: "nvarchar(450)",
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

            migrationBuilder.AddColumn<string>(
                name: "IdRecursoAnalistaEmail",
                table: "Apontamentos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdRecursoAnalistaRecursoId",
                table: "Apontamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                columns: new[] { "RecursoId", "Email" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                columns: new[] { "ClienteId", "Email" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos",
                columns: new[] { "ApontamentoId", "OS" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_IdProjetoProjetoId",
                table: "Tarefas",
                column: "IdProjetoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_IdRecursoCoordenadorRecursoId_IdRecursoCoordenadorEmail",
                table: "Tarefas",
                columns: new[] { "IdRecursoCoordenadorRecursoId", "IdRecursoCoordenadorEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_IdApontamentoApontamentoId_IdApontamentoOS",
                table: "SubTarefas",
                columns: new[] { "IdApontamentoApontamentoId", "IdApontamentoOS" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "SubTarefas",
                columns: new[] { "IdRecursoAnalistaRecursoId", "IdRecursoAnalistaEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IdClienteClienteId_IdClienteEmail",
                table: "Projeto",
                columns: new[] { "IdClienteClienteId", "IdClienteEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IdGerenteRecursoId_IdGerenteEmail",
                table: "Projeto",
                columns: new[] { "IdGerenteRecursoId", "IdGerenteEmail" });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_IdServicoServicoId",
                table: "Empresas",
                column: "IdServicoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEmpresaEmpresaId",
                table: "Clientes",
                column: "IdEmpresaEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdServicoServicoId",
                table: "Clientes",
                column: "IdServicoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "Apontamentos",
                columns: new[] { "IdRecursoAnalistaRecursoId", "IdRecursoAnalistaEmail" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "Apontamentos",
                columns: new[] { "IdRecursoAnalistaRecursoId", "IdRecursoAnalistaEmail" },
                principalTable: "Recursos",
                principalColumns: new[] { "RecursoId", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_IdEmpresaEmpresaId",
                table: "Clientes",
                column: "IdEmpresaEmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Servicos_IdServicoServicoId",
                table: "Clientes",
                column: "IdServicoServicoId",
                principalTable: "Servicos",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Servicos_IdServicoServicoId",
                table: "Empresas",
                column: "IdServicoServicoId",
                principalTable: "Servicos",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Clientes_IdClienteClienteId_IdClienteEmail",
                table: "Projeto",
                columns: new[] { "IdClienteClienteId", "IdClienteEmail" },
                principalTable: "Clientes",
                principalColumns: new[] { "ClienteId", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Recursos_IdGerenteRecursoId_IdGerenteEmail",
                table: "Projeto",
                columns: new[] { "IdGerenteRecursoId", "IdGerenteEmail" },
                principalTable: "Recursos",
                principalColumns: new[] { "RecursoId", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Apontamentos_IdApontamentoApontamentoId_IdApontamentoOS",
                table: "SubTarefas",
                columns: new[] { "IdApontamentoApontamentoId", "IdApontamentoOS" },
                principalTable: "Apontamentos",
                principalColumns: new[] { "ApontamentoId", "OS" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "SubTarefas",
                columns: new[] { "IdRecursoAnalistaRecursoId", "IdRecursoAnalistaEmail" },
                principalTable: "Recursos",
                principalColumns: new[] { "RecursoId", "Email" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projeto_IdProjetoProjetoId",
                table: "Tarefas",
                column: "IdProjetoProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_IdRecursoCoordenadorRecursoId_IdRecursoCoordenadorEmail",
                table: "Tarefas",
                columns: new[] { "IdRecursoCoordenadorRecursoId", "IdRecursoCoordenadorEmail" },
                principalTable: "Recursos",
                principalColumns: new[] { "RecursoId", "Email" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_IdEmpresaEmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Servicos_IdServicoServicoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Servicos_IdServicoServicoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_IdClienteClienteId_IdClienteEmail",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_IdGerenteRecursoId_IdGerenteEmail",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Apontamentos_IdApontamentoApontamentoId_IdApontamentoOS",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projeto_IdProjetoProjetoId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_IdRecursoCoordenadorRecursoId_IdRecursoCoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_IdProjetoProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_IdRecursoCoordenadorRecursoId_IdRecursoCoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_IdApontamentoApontamentoId_IdApontamentoOS",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_IdClienteClienteId_IdClienteEmail",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_IdGerenteRecursoId_IdGerenteEmail",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_IdServicoServicoId",
                table: "Empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEmpresaEmpresaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdServicoServicoId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_IdRecursoAnalistaRecursoId_IdRecursoAnalistaEmail",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "IdProjetoProjetoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdRecursoCoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdRecursoCoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdApontamentoApontamentoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdApontamentoOS",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdRecursoAnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdRecursoAnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "IdClienteClienteId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IdClienteEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IdGerenteEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IdGerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IdServicoServicoId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "IdEmpresaEmpresaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdServicoServicoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdRecursoAnalistaEmail",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "IdRecursoAnalistaRecursoId",
                table: "Apontamentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "TarefaId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordenadorRecursoId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjetoId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubTarefaId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "AnalistaRecursoId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TarefaId",
                table: "SubTarefas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServicoId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecursoId",
                table: "Recursos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjetoId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GerenteRecursoId",
                table: "Projeto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "Empresas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Apontamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApontamentoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "RecursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos",
                column: "ApontamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_AnalistaRecursoId",
                table: "SubTarefas",
                column: "AnalistaRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ClienteId",
                table: "Projeto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GerenteRecursoId",
                table: "Projeto",
                column: "GerenteRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes",
                column: "EmpresaId");

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
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Clientes_ClienteId",
                table: "Projeto",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Recursos_GerenteRecursoId",
                table: "Projeto",
                column: "GerenteRecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaRecursoId",
                table: "SubTarefas",
                column: "AnalistaRecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaId",
                table: "SubTarefas",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projeto",
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
