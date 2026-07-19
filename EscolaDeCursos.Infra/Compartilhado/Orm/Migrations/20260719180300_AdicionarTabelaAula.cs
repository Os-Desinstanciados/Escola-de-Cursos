using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCurso_TBCategoria_CategoriaId",
                table: "TBCurso");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "TBCurso",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "TBAula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAula_TBCurso",
                        column: x => x.CursoId,
                        principalTable: "TBCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_TBCurso_Nome",
                table: "TBCurso",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAula_CursoId_Ordem",
                table: "TBAula",
                columns: new[] { "CursoId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAula_Nome",
                table: "TBAula",
                column: "Nome",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCurso_TBCategoria",
                table: "TBCurso",
                column: "CategoriaId",
                principalTable: "TBCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCurso_TBCategoria",
                table: "TBCurso");

            migrationBuilder.DropTable(
                name: "TBAula");

            migrationBuilder.DropIndex(
                name: "UQ_TBCurso_Nome",
                table: "TBCurso");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "TBCurso",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCurso_TBCategoria_CategoriaId",
                table: "TBCurso",
                column: "CategoriaId",
                principalTable: "TBCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
