using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotiIpt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Terceira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoDia",
                table: "Dados");

            migrationBuilder.AlterColumn<string>(
                name: "Luz",
                table: "Dados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "lumino",
                table: "Dados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lumino",
                table: "Dados");

            migrationBuilder.AlterColumn<bool>(
                name: "Luz",
                table: "Dados",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoDia",
                table: "Dados",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
