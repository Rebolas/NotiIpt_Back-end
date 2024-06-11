using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotiIpt.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sexta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dados",
                table: "Dados");

            migrationBuilder.AlterColumn<string>(
                name: "DataHora",
                table: "Dados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dados",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dados",
                table: "Dados",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dados",
                table: "Dados");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dados");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                table: "Dados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dados",
                table: "Dados",
                column: "DataHora");
        }
    }
}
