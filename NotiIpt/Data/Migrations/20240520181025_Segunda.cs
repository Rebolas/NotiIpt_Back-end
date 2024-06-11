using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotiIpt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriasId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_CategoriasId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "CategoriasId",
                table: "Noticias");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizadores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImagemPerf",
                table: "Utilizadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaFK",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_CategoriaFK",
                table: "Noticias",
                column: "CategoriaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Categorias_CategoriaFK",
                table: "Noticias",
                column: "CategoriaFK",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriaFK",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_CategoriaFK",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "ImagemPerf",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "CategoriaFK",
                table: "Noticias");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriasId",
                table: "Noticias",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_CategoriasId",
                table: "Noticias",
                column: "CategoriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Categorias_CategoriasId",
                table: "Noticias",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }
    }
}
