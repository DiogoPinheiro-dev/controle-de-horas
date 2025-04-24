using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_GerenteRecursoId",
                table: "Projeto");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_AnalistaRecursoId",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ClienteId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
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
                name: "ClienteId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "RecursoId",
                table: "Apontamentos");

            migrationBuilder.RenameColumn(
                name: "IdSubTarefa",
                table: "SubTarefas",
                newName: "SubTarefaId");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailCoordenador",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoordenadorEmail",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjetoEmailCliente",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjetoEmailGerente",
                table: "Tarefas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "SubTarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "TarefaEmailCoordenador",
                table: "SubTarefas",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Recursos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Projeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailCliente",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailGerente",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClienteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GerenteEmail",
                table: "Projeto",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Apontamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecursoEmail",
                table: "Apontamentos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "EmailCoordenador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas",
                column: "IdTarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                columns: new[] { "EmailCliente", "EmailGerente" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos",
                column: "OS");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorEmail",
                table: "Tarefas",
                column: "CoordenadorEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas",
                columns: new[] { "ProjetoEmailCliente", "ProjetoEmailGerente" });

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_AnalistaEmail",
                table: "SubTarefas",
                column: "AnalistaEmail");

            migrationBuilder.CreateIndex(
                name: "IX_SubTarefas_TarefaEmailCoordenador",
                table: "SubTarefas",
                column: "TarefaEmailCoordenador");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ClienteEmail",
                table: "Projeto",
                column: "ClienteEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GerenteEmail",
                table: "Projeto",
                column: "GerenteEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoEmail",
                table: "Apontamentos",
                column: "RecursoEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail",
                table: "Apontamentos",
                column: "RecursoEmail",
                principalTable: "Recursos",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail",
                table: "Projeto",
                column: "ClienteEmail",
                principalTable: "Clientes",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Recursos_GerenteEmail",
                table: "Projeto",
                column: "GerenteEmail",
                principalTable: "Recursos",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaEmail",
                table: "SubTarefas",
                column: "AnalistaEmail",
                principalTable: "Recursos",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador",
                table: "SubTarefas",
                column: "TarefaEmailCoordenador",
                principalTable: "Tarefas",
                principalColumn: "EmailCoordenador");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas",
                columns: new[] { "ProjetoEmailCliente", "ProjetoEmailGerente" },
                principalTable: "Projeto",
                principalColumns: new[] { "EmailCliente", "EmailGerente" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorEmail",
                table: "Tarefas",
                column: "CoordenadorEmail",
                principalTable: "Recursos",
                principalColumn: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_GerenteEmail",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Recursos_AnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTarefas_Tarefas_TarefaEmailCoordenador",
                table: "SubTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projeto_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoEmailCliente_ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_AnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaEmailCoordenador",
                table: "SubTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ClienteEmail",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_GerenteEmail",
                table: "Projeto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_RecursoEmail",
                table: "Apontamentos");

            migrationBuilder.DropColumn(
                name: "EmailCoordenador",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "CoordenadorEmail",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoEmailCliente",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoEmailGerente",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "IdTarefa",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "AnalistaEmail",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "TarefaEmailCoordenador",
                table: "SubTarefas");

            migrationBuilder.DropColumn(
                name: "EmailCliente",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "EmailGerente",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "ClienteEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "GerenteEmail",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "RecursoEmail",
                table: "Apontamentos");

            migrationBuilder.RenameColumn(
                name: "SubTarefaId",
                table: "SubTarefas",
                newName: "IdSubTarefa");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Tarefas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "SubTarefas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Projeto",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Apontamentos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "TarefaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas",
                column: "IdSubTarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "RecursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                column: "ProjetoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos",
                columns: new[] { "ApontamentoId", "OS" });

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
                name: "IX_Projeto_ClienteId",
                table: "Projeto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GerenteRecursoId",
                table: "Projeto",
                column: "GerenteRecursoId");

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
