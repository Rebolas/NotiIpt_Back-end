using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotiIpt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dados",
                columns: table => new
                {
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    Humidade = table.Column<int>(type: "int", nullable: false),
                    EstadoDia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Luz = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dados", x => x.DataHora);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEscrita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FotosNoticias",
                columns: table => new
                {
                    ListaFotosId = table.Column<int>(type: "int", nullable: false),
                    ListaNoticiasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosNoticias", x => new { x.ListaFotosId, x.ListaNoticiasId });
                    table.ForeignKey(
                        name: "FK_FotosNoticias_Fotos_ListaFotosId",
                        column: x => x.ListaFotosId,
                        principalTable: "Fotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotosNoticias_Noticias_ListaNoticiasId",
                        column: x => x.ListaNoticiasId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    Contacto = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoticiasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Noticias_NoticiasId",
                        column: x => x.NoticiasId,
                        principalTable: "Noticias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotosNoticias_ListaNoticiasId",
                table: "FotosNoticias",
                column: "ListaNoticiasId");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_CategoriasId",
                table: "Noticias",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_NoticiasId",
                table: "Utilizadores",
                column: "NoticiasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dados");

            migrationBuilder.DropTable(
                name: "FotosNoticias");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
