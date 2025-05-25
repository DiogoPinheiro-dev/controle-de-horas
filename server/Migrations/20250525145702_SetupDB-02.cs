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
                name: "FK_Projetos_Recursos_GerenteRecursoId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_GerenteRecursoId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "GerenteRecursoId",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "DataIni",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DataFim",
                table: "Projetos",
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
            migrationBuilder.AlterColumn<string>(
                name: "DataIni",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DataFim",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GerenteRecursoId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_GerenteRecursoId",
                table: "Projetos",
                column: "GerenteRecursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Recursos_GerenteRecursoId",
                table: "Projetos",
                column: "GerenteRecursoId",
                principalTable: "Recursos",
                principalColumn: "RecursoId");
        }
    }
}
