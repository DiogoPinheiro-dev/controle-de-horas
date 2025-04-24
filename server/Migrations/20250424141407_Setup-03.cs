using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Setup03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ProjetoEmailCliente",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoEmailGerente",
                table: "Tarefas");

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

            migrationBuilder.AddColumn<Guid>(
                name: "RecursoId",
                table: "Apontamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                columns: new[] { "EmailCoordenador", "TarefaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTarefas",
                table: "SubTarefas",
                columns: new[] { "IdTarefa", "SubTarefaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                columns: new[] { "Email", "RecursoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                column: "ProjetoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                columns: new[] { "Email", "ClienteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos",
                columns: new[] { "OS", "ApontamentoId" });

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
                name: "IX_SubTarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas",
                columns: new[] { "TarefaEmailCoordenador", "TarefaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ClienteEmail_ClienteId",
                table: "Projeto",
                columns: new[] { "ClienteEmail", "ClienteId" });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GerenteEmail_GerenteRecursoId",
                table: "Projeto",
                columns: new[] { "GerenteEmail", "GerenteRecursoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_RecursoEmail_RecursoId",
                table: "Apontamentos",
                columns: new[] { "RecursoEmail", "RecursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos",
                columns: new[] { "RecursoEmail", "RecursoId" },
                principalTable: "Recursos",
                principalColumns: new[] { "Email", "RecursoId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apontamentos_Recursos_RecursoEmail_RecursoId",
                table: "Apontamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Clientes_ClienteEmail_ClienteId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Recursos_GerenteEmail_GerenteRecursoId",
                table: "Projeto");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
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

            migrationBuilder.DropIndex(
                name: "IX_SubTarefas_TarefaEmailCoordenador_TarefaId",
                table: "SubTarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_ClienteEmail_ClienteId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_GerenteEmail_GerenteRecursoId",
                table: "Projeto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apontamentos",
                table: "Apontamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apontamentos_RecursoEmail_RecursoId",
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
    }
}
