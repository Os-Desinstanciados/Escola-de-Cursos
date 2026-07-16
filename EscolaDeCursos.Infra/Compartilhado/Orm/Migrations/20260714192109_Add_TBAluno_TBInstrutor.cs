using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBAluno_TBInstrutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBInstrutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBInstrutor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Email",
                table: "TBAluno",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Telefone",
                table: "TBAluno",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_Email",
                table: "TBInstrutor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_Telefone",
                table: "TBInstrutor",
                column: "Telefone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAluno");

            migrationBuilder.DropTable(
                name: "TBInstrutor");
        }
    }
}