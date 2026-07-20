using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class RefatoraInstrutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "TBAluno");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "TBInstrutor",
                newName: "Graduacao");

            migrationBuilder.AddColumn<string>(
                name: "NumeroMatricula",
                table: "TBAluno",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_Nome",
                table: "TBInstrutor",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_NumeroMatricula",
                table: "TBAluno",
                column: "NumeroMatricula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBInstrutor_Nome",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "UQ_TBAluno_NumeroMatricula",
                table: "TBAluno");

            migrationBuilder.DropColumn(
                name: "NumeroMatricula",
                table: "TBAluno");

            migrationBuilder.RenameColumn(
                name: "Graduacao",
                table: "TBInstrutor",
                newName: "Endereco");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "TBAluno",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
