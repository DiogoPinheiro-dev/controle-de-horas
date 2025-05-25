using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SetupBD03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "CoordenadorRecursoId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "DescricaoTarefa",
                table: "Tarefas",
                newName: "Descricao");

            migrationBuilder.AlterColumn<int>(
                name: "DataInicio",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DataFim",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Tarefas",
                newName: "DescricaoTarefa");

            migrationBuilder.AlterColumn<string>(
                name: "DataInicio",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DataFim",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CoordenadorRecursoId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Recursos_CoordenadorRecursoId",
                table: "Tarefas",
                column: "CoordenadorRecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");
        }
    }
}
